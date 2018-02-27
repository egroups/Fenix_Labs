<%-- 
    Document   : proveedores
    Created on : 29-abr-2016, 23:04:54
    Author     : Doddy
--%>

<%@page import="Funciones.Funciones"%>
<%@page import="Modelo.Proveedor"%>
<%@page import="java.util.ArrayList"%>
<%@page import="Controlador.Conexion"%>

<%
    if (request.getParameter("proveedores") != null) {

        Conexion conexion_proveedor = new Conexion();
        Funciones funcion_proveedor = new Funciones();

        Cookie[] cookies_proveedor = request.getCookies();

        if (cookies_proveedor != null) {
            if (funcion_proveedor.validar_cookie(cookies_proveedor)) {

                ArrayList listaProveedores = new ArrayList();

                if (request.getParameter("busqueda") != null) {
                    listaProveedores = conexion_proveedor.listarProveedoresEnTabla(request.getParameter("nombre_buscar"));
                } else {
                    listaProveedores = conexion_proveedor.listarProveedoresEnTabla("");
                }

                int cantidad_real = listaProveedores.size();

                out.println("<div class='login'>");
                out.println("<h1>Proveedores encontrados : " + cantidad_real + "</h1>");

                if (request.getParameter("busqueda") != null) {

                    if (cantidad_real == 0) {
                        out.println("<center><b>No se encontraron proveedores</b></center>");
                    } else {
                        out.println("<div class='datagrid'>");
                        out.println("<table><thead>");
                        out.println("<th>Nombre empresa</th><th>Direccion</th><th>Telefono</th><th>Fecha registro</th><th>Opción</th>");

                        for (int i = 0; i < listaProveedores.size(); i++) {
                            Proveedor proveedor = (Proveedor) listaProveedores.get(i);
                            int id_proveedor = proveedor.getId_proveedor();
                            String nombre_empresa = proveedor.getNombre_empresa();
                            String direccion = proveedor.getDireccion();
                            int telefono = proveedor.getTelefono();
                            String fecha_registro = proveedor.getFecha_registro();
                            out.println("<tr>");
                            out.println("<td>" + nombre_empresa + "</td>");
                            out.println("<td>" + direccion + "</td>");
                            out.println("<td>" + telefono + "</td>");
                            out.println("<td>" + fecha_registro + "</td>");
                            out.println("<td><a href=?proveedores=&editar_proveedor=" + id_proveedor + "><img src='images/edit.png' title='Editar'></a> <a href=Proveedores?borrar_proveedor=" + id_proveedor + "><img src='images/delete.png' title='Borrar'></a></td>");
                            out.println("</tr>");
                        }

                        out.println("</thead></table>");
                        out.println("</div><br>");
                    }

                } else {
                    out.println("<br><form action='?proveedores' method='POST'>");
                    out.println("<b>Nombre : </b><input type='text' name='nombre_buscar'>");
                    out.println("<button class='small button' name='busqueda' type='submit'>Buscar</button>");
                    out.println("</form>");
                }

                out.println("</div><br>");

                if (request.getParameter("editar_proveedor") == null) {
                    out.println("<div class='login'>");
                    out.println("<center>");
                    out.println("<h1>Agregar proveedor</h1><form action='Proveedores' method='POST'>");
                    out.println("<b>Nombre empresa : </b><input type='text' name='nombre_empresa'><br>");
                    out.println("<b>Direccion : </b><input type='text' name='direccion'><br>");
                    out.println("<b>Telefono : </b><input type='text' name='telefono'><br><br>");
                    out.println("<button class='small button' name='agregar_proveedor' type='submit'>Agregar</button>");
                    out.println("</div></form></center><br>");
                } else {
                    String id_proveedor = request.getParameter("editar_proveedor");
                    if (funcion_proveedor.valid_number(id_proveedor)) {

                        Proveedor proveedor_load = conexion_proveedor.listarProveedorEnTabla(Integer.parseInt(id_proveedor));

                        if (proveedor_load.getId_proveedor() > 0) {

                            int id_proveedor_real = proveedor_load.getId_proveedor();
                            String nombre_empresa = proveedor_load.getNombre_empresa();
                            String direccion = proveedor_load.getDireccion();
                            int telefono = proveedor_load.getTelefono();
                            String fecha_registro = proveedor_load.getFecha_registro();

                            out.println("<div class='login'>");
                            out.println("<center>");
                            out.println("<h1>Editando al proveedor " + nombre_empresa + "</h1><form action='Proveedores' method='POST'>");
                            out.println("<input type='hidden' name='id_proveedor' value='" + id_proveedor_real + "'>");
                            out.println("<b>Nombre empresa : </b><input type='text' name='nombre_empresa' value='" + nombre_empresa + "'><br>");
                            out.println("<b>Direccion : </b><input type='text' name='direccion' value='" + direccion + "'><br>");
                            out.println("<b>Telefono : </b><input type='text' name='telefono' value='" + telefono + "'><br><br>");
                            out.println("<button class='small button' name='actualizar_proveedor' type='submit'>Editar</button>");
                            out.println("</div></form></center><br>");

                        } else {
                            out.println(funcion_proveedor.Redirect("Proveedor inexistente", "administracion.jsp?proveedores"));
                        }
                    } else {
                        out.println(funcion_proveedor.Redirect("ID invalido", "administracion.jsp?proveedores"));
                    }
                }

            } else {
                response.sendRedirect("login.jsp");
            }
        } else {
            response.sendRedirect("login.jsp");
        }

    }
%>