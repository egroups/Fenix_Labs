<%-- 
    Document   : usuarios
    Created on : 03-may-2016, 22:49:06
    Author     : Doddy
--%>

<%@page import="Funciones.Funciones"%>
<%@page import="Modelo.Usuario"%>
<%@page import="Modelo.Proveedor"%>
<%@page import="java.util.ArrayList"%>
<%@page import="Controlador.Conexion"%>

<%
    if (request.getParameter("usuarios") != null) {

        Conexion conexion_usuario = new Conexion();
        Funciones funcion_usuario = new Funciones();

        Cookie[] cookies_usuario = request.getCookies();
        String admin_check = funcion_usuario.get_username_cookie(cookies_usuario);

        if (cookies_usuario != null) {
            if (funcion_usuario.validar_cookie(cookies_usuario)) {
                if (conexion_usuario.es_admin(admin_check)) {
                    ArrayList listaUsuarios = new ArrayList();

                    if (request.getParameter("busqueda") != null) {
                        listaUsuarios = conexion_usuario.listarUsuariosEnTabla(request.getParameter("nombre_buscar"));
                    } else {
                        listaUsuarios = conexion_usuario.listarUsuariosEnTabla("");
                    }

                    int cantidad_real = listaUsuarios.size();

                    out.println("<div class='login'>");
                    out.println("<h1>Usuarios encontrados : " + cantidad_real + "</h1>");

                    if (request.getParameter("busqueda") != null) {

                        if (cantidad_real == 0) {
                            out.println("<center><b>No se encontraron usuarios</b></center>");
                        } else {
                            out.println("<div class='datagrid'>");
                            out.println("<table><thead>");
                            out.println("<th>Nombre</th><th>Tipo</th><th>Fecha registro</th><th>Opción</th>");

                            for (int i = 0; i < listaUsuarios.size(); i++) {
                                Usuario usuario_load = (Usuario) listaUsuarios.get(i);
                                int id_usuario = usuario_load.getId_usuario();
                                String nombre_usuario = usuario_load.getNombre();
                                String password = usuario_load.getPassword();
                                int tipo = usuario_load.getTipo();
                                String fecha_registro = usuario_load.getFecha_registro();
                                String tipo_nombre = "";
                                if (tipo == 1) {
                                    tipo_nombre = "Administrador";
                                } else {
                                    tipo_nombre = "Usuario";
                                }
                                out.println("<tr>");
                                out.println("<td>" + nombre_usuario + "</td>");
                                out.println("<td>" + tipo_nombre + "</td>");
                                out.println("<td>" + fecha_registro + "</td>");
                                out.println("<td><a href=?usuarios=&editar_usuario=" + id_usuario + "><img src='images/edit.png' title='Editar'></a> <a href=Usuarios?borrar_usuario=" + id_usuario + "><img src='images/delete.png' title='Borrar'></a></td>");
                                out.println("</tr>");
                            }

                            out.println("</thead></table>");
                            out.println("</div><br>");
                        }

                    } else {
                        out.println("<br><form action='?usuarios' method='POST'>");
                        out.println("<b>Nombre : </b><input type='text' name='nombre_buscar'>");
                        out.println("<button class='small button' name='busqueda' type='submit'>Buscar</button>");
                        out.println("</form>");
                    }

                    out.println("</div><br>");

                    if (request.getParameter("editar_usuario") == null) {
                        out.println("<div class='login'>");
                        out.println("<center>");
                        out.println("<h1>Agregar usuario</h1><form action='Usuarios' method='POST'>");
                        out.println("<b>Nombre usuario : </b><input type='text' name='nombre_usuario'><br>");
                        out.println("<b>Password : </b><input type='password' name='password'><br><br>");
                        out.println("<b>Tipo : </b><select name='tipo'>");
                        out.println("<option value='2'>Usuario</option>");
                        out.println("<option value='1'>Administrador</option>");
                        out.println("</select><br><br>");
                        out.println("<button class='small button' name='agregar_usuario' type='submit'>Agregar</button>");
                        out.println("</div></form></center><br>");
                    } else {
                        String id_usuario = request.getParameter("editar_usuario");
                        if (funcion_usuario.valid_number(id_usuario)) {

                            Usuario usuario_load = conexion_usuario.listarUsuarioEnTabla(Integer.parseInt(id_usuario));

                            if (usuario_load.getId_usuario() > 0) {

                                int id_usuario_real = usuario_load.getId_usuario();
                                String nombre_usuario = usuario_load.getNombre();
                                String password = usuario_load.getPassword();
                                int tipo = usuario_load.getTipo();
                                String fecha_registro = usuario_load.getFecha_registro();
                                String tipo_nombre = "";
                                if (tipo == 1) {
                                    tipo_nombre = "Administrador";
                                } else {
                                    tipo_nombre = "Usuario";
                                }

                                out.println("<div class='login'>");
                                out.println("<center>");
                                out.println("<h1>Editar al usuario " + nombre_usuario + "</h1><form action='Usuarios' method='POST'>");
                                out.println("<input type='hidden' name='id_usuario' value='" + id_usuario_real + "'>");
                                out.println("<b>Nombre usuario : </b><input type='text' name='nombre_usuario' value='" + nombre_usuario + "' readonly='readonly'><br>");
                                out.println("<b>Password : </b><input type='password' name='password' readonly='readonly'><br><br>");
                                out.println("<b>Tipo : </b><select name='tipo'>");
                                if (tipo == 1) {
                                    out.println("<option value='2'>Usuario</option>");
                                    out.println("<option value='1' selected='true'>Administrador</option>");
                                } else {
                                    out.println("<option value='2' selected='true'>Usuario</option>");
                                    out.println("<option value='1'>Administrador</option>");
                                }
                                out.println("</select><br><br>");
                                out.println("<button class='small button' name='actualizar_usuario' type='submit'>Editar</button>");
                                out.println("</div></form></center><br>");

                            } else {
                                out.println(funcion_usuario.Redirect("Usuario inexistente", "administracion.jsp?usuarios"));
                            }
                        } else {
                            out.println(funcion_usuario.Redirect("ID invalido", "administracion.jsp?usuarios"));
                        }
                    }
                } else {
                    out.println(funcion_usuario.Redirect("Acceso Denegado", "administracion.jsp"));
                }
            } else {
                response.sendRedirect("login.jsp");
            }
        } else {
            response.sendRedirect("login.jsp");
        }
    }
%>
