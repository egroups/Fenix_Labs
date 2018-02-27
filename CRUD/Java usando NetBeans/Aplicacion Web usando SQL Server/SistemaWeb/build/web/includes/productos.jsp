<%-- 
    Document   : productos
    Created on : 02-may-2016, 13:27:48
    Author     : Doddy
--%>

<%@page import="Funciones.Funciones"%>
<%@page import="Modelo.Producto"%>
<%@page import="Modelo.Proveedor"%>
<%@page import="java.util.ArrayList"%>
<%@page import="Controlador.Conexion"%>

<%
    if (request.getParameter("productos") != null) {

        Conexion conexion_producto = new Conexion();
        Funciones funcion_producto = new Funciones();

        Cookie[] cookies_producto = request.getCookies();

        if (cookies_producto != null) {
            if (funcion_producto.validar_cookie(cookies_producto)) {

                ArrayList listaProveedores = conexion_producto.listarProveedoresEnTabla("");

                ArrayList listaProductos = new ArrayList();

                if (request.getParameter("busqueda") != null) {
                    listaProductos = conexion_producto.listarProductosEnTabla(request.getParameter("nombre_buscar"));
                } else {
                    listaProductos = conexion_producto.listarProductosEnTabla("");
                }

                int cantidad_real = listaProductos.size();
                int cantidad_proveedores = listaProveedores.size();

                out.println("<div class='login'>");
                out.println("<h1>Productos encontrados : " + cantidad_real + "</h1>");

                if (request.getParameter("busqueda") != null) {

                    if (cantidad_real == 0) {
                        out.println("<center><b>No se encontraron productos</b></center>");
                    } else {
                        out.println("<div class='datagrid'>");
                        out.println("<table><thead>");
                        out.println("<th>Nombre producto</th><th>Descripcion</th><th>Precio</th><th>Proveedor</th><th>Fecha registro</th><th>Opción</th>");

                        for (int i = 0; i < listaProductos.size(); i++) {

                            Producto producto = (Producto) listaProductos.get(i);

                            int id_producto = producto.getId_producto();
                            String nombre_producto = producto.getNombre_producto();
                            String descripcion = producto.getDescripcion();
                            String descripcion_cortada = "";
                            if (descripcion_cortada.length() >= 15) {
                                descripcion_cortada = descripcion.substring(0, 15);
                            } else {
                                descripcion_cortada = descripcion;
                            }
                            double precio = producto.getPrecio();
                            String fecha_registro = producto.getFecha_registro();
                            int id_proveedor = producto.getId_proveedor();
                            String nombre_proveedor = conexion_producto.cargarNombreProveedor(id_proveedor);
                            out.println("<tr>");
                            out.println("<td>" + nombre_producto + "</td>");
                            out.println("<td>" + descripcion_cortada + "</td>");
                            out.println("<td>" + precio + "</td>");
                            out.println("<td>" + nombre_proveedor + "</td>");
                            out.println("<td>" + fecha_registro + "</td>");
                            out.println("<td><a href=?productos=&editar_producto=" + id_producto + "><img src='images/edit.png' title='Editar'></a> <a href=Productos?borrar_producto=" + id_producto + "><img src='images/delete.png' title='Borrar'></a></td>");
                            out.println("</tr>");
                        }

                        out.println("</thead></table>");
                        out.println("</div><br>");
                    }

                } else {
                    out.println("<br><form action='?productos' method='POST'>");
                    out.println("<b>Nombre : </b><input type='text' name='nombre_buscar'>");
                    out.println("<button class='small button' name='busqueda' type='submit'>Buscar</button>");
                    out.println("</form>");
                }

                out.println("</div><br>");

                if (request.getParameter("editar_producto") == null) {
                    out.println("<div class='login'>");
                    out.println("<center>");
                    out.println("<h1>Agregar producto</h1><form action='Productos' method='POST'>");
                    out.println("<b>Nombre producto : </b><input type='text' name='nombre_producto'><br><br>");
                    out.println("<b>Descripción : </b><br><br><textarea cols=50 rows=10 name='descripcion' style='border-style: inset;;border-width: 1px;border-color:black;'></textarea><br><br>");
                    out.println("<b>Precio : &nbsp;$</b><input type='text' name='precio' style='width: 80px;'><br><br>");

                    if (cantidad_proveedores == 0) {
                        out.println("<b>Proveedor : </b><select name='proveedor' style='border-style: inset;;border-width: 1px;border-color:black;'>");
                        out.println("<option value='null'>No se encontraron proveedores</option>");
                        out.println("</select><br><br>");
                    } else {
                        out.println("<b>Proveedor : </b><select name='proveedor' style='border-style: inset;;border-width: 1px;border-color:black;'>");
                        for (int i = 0; i < listaProveedores.size(); i++) {
                            Proveedor proveedor = (Proveedor) listaProveedores.get(i);
                            int id_proveedor = proveedor.getId_proveedor();
                            String nombre_empresa = proveedor.getNombre_empresa();
                            out.println("<option value='" + id_proveedor + "'>" + nombre_empresa + "</option>");
                        }
                        out.println("</select><br><br>");
                    }
                    out.println("<button class='small button' name='agregar_producto' type='submit'>Agregar</button>");
                    out.println("</div></form></center><br>");
                } else {
                    String id_producto = request.getParameter("editar_producto");
                    if (funcion_producto.valid_number(id_producto)) {

                        Producto producto_load = conexion_producto.listarProductoEnTabla(Integer.parseInt(id_producto));

                        if (producto_load.getId_producto() > 0) {

                            int id_producto_real = producto_load.getId_producto();
                            String nombre_producto = producto_load.getNombre_producto();
                            String descripcion = producto_load.getDescripcion();
                            double precio = producto_load.getPrecio();
                            String fecha_registro = producto_load.getFecha_registro();
                            int id_proveedor = producto_load.getId_proveedor();
                            String nombre_proveedor = conexion_producto.cargarNombreProveedor(id_proveedor);

                            out.println("<div class='login'>");
                            out.println("<center>");
                            out.println("<h1>Editar al producto " + nombre_producto + "</h1><form action='Productos' method='POST'>");
                            out.println("<input type='hidden' name='id_producto' value='" + id_producto_real + "'>");
                            out.println("<b>Nombre producto : </b><input type='text' name='nombre_producto' value='" + nombre_producto + "'><br><br>");
                            out.println("<b>Descripción : </b><br><br><textarea cols=50 rows=10 name='descripcion' style='border-style: inset;;border-width: 1px;border-color:black;'>" + descripcion + "</textarea><br><br>");
                            out.println("<b>Precio : &nbsp;$</b><input type='text' name='precio' value='" + precio + "' style='width: 80px;'><br><br>");

                            if (cantidad_proveedores == 0) {
                                out.println("<b>Proveedor : </b><select name='proveedor' style='border-style: inset;;border-width: 1px;border-color:black;'>");
                                out.println("<option value='null'>No se encontraron proveedores</option>");
                                out.println("</select><br><br>");
                            } else {
                                out.println("<b>Proveedor : </b><select name='proveedor' style='border-style: inset;;border-width: 1px;border-color:black;'>");
                                for (int i = 0; i < listaProveedores.size(); i++) {
                                    Proveedor proveedor = (Proveedor) listaProveedores.get(i);
                                    int id_proveedor_loader = proveedor.getId_proveedor();
                                    String nombre_empresa = proveedor.getNombre_empresa();
                                    if (id_proveedor == id_proveedor_loader) {
                                        out.println("<option value='" + id_proveedor_loader + "' selected='true'>" + nombre_empresa + "</option>");
                                    } else {
                                        out.println("<option value='" + id_proveedor_loader + "'>" + nombre_empresa + "</option>");
                                    }
                                }
                                out.println("</select><br><br>");
                            }
                            out.println("<button class='small button' name='actualizar_producto' type='submit'>Editar</button>");
                            out.println("</div></form></center><br>");

                        } else {
                            out.println(funcion_producto.Redirect("Proveedor inexistente", "administracion.jsp?proveedores"));
                        }
                    } else {
                        out.println(funcion_producto.Redirect("ID invalido", "administracion.jsp?proveedores"));
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
