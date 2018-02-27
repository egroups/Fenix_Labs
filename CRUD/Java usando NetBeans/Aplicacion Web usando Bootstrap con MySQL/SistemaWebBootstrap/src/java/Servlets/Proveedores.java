// Written by Ismael Heredia in the year 2016

package Servlets;

import Controlador.AccesoDatos;
import Controlador.Conexion;
import Funciones.Funciones;
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@WebServlet(name = "Proveedores", urlPatterns = {"/Proveedores"})
public class Proveedores extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {

            AccesoDatos conexion_now = new AccesoDatos();
            Funciones funcion = new Funciones();

            Cookie[] cookies = request.getCookies();

            if (cookies != null) {
                if (funcion.validar_cookie(cookies)) {

                    if (request.getParameter("agregar_proveedor") != null) {

                        String nombre_empresa = request.getParameter("nombre_empresa");
                        String direccion = request.getParameter("direccion");
                        String telefono = request.getParameter("telefono");
                        String fecha_registro = funcion.fecha_del_dia();

                        if (!"".equals(nombre_empresa) && !"".equals(direccion) && funcion.valid_number(telefono) && !"".equals(fecha_registro)) {
                            if (conexion_now.comprobar_existencia_proveedor_crear(nombre_empresa)) {
                                out.println(funcion.Redirect("Proveedores", "El proveedor " + nombre_empresa + " ya existe", "warning", "administracion.jsp?proveedores"));
                            } else {
                                String sql = "insert into proveedores(nombre_empresa,direccion,telefono,fecha_registro_proveedor) values('" + nombre_empresa + "','" + direccion + "'," + telefono + ",'" + fecha_registro + "')";
                                if (conexion_now.cargarConsulta(sql)) {
                                    out.println(funcion.Redirect("Proveedores", "Proveedor registrado", "success", "administracion.jsp?proveedores"));
                                } else {
                                    out.println(funcion.Redirect("Proveedores", "Ha ocurrido un error en la base de datos", "error", "administracion.jsp?proveedores"));
                                }
                            }
                        } else {
                            out.println(funcion.Redirect("Proveedores", "Faltan datos", "warning", "administracion.jsp?proveedores"));
                        }

                    } else if (request.getParameter("editar_proveedor") != null) {

                        String id_proveedor = request.getParameter("id_proveedor");
                        String nombre_empresa = request.getParameter("nombre_empresa");
                        String direccion = request.getParameter("direccion");
                        String telefono = request.getParameter("telefono");

                        if (funcion.valid_number(id_proveedor) && !"".equals(nombre_empresa) && !"".equals(direccion) && funcion.valid_number(telefono)) {
                            if (conexion_now.comprobar_existencia_proveedor_editar(Integer.parseInt(id_proveedor), nombre_empresa)) {
                                out.println(funcion.Redirect("Proveedores", "El proveedor " + nombre_empresa + " ya existe", "warning", "administracion.jsp?proveedores"));
                            } else {
                                String sql = "update proveedores set nombre_empresa='" + nombre_empresa + "',direccion='" + direccion + "',telefono=" + telefono + " where id_proveedor=" + id_proveedor;
                                if (conexion_now.cargarConsulta(sql)) {
                                    out.println(funcion.Redirect("Proveedores", "Proveedor editado", "success", "administracion.jsp?proveedores"));
                                } else {
                                    out.println(funcion.Redirect("Proveedores", "Ha ocurrido un error en la base de datos", "error", "administracion.jsp?proveedores"));
                                }
                            }
                        } else {
                            out.println(funcion.Redirect("Proveedores", "Faltan datos", "warning", "administracion.jsp?proveedores"));
                        }

                    } else if (request.getParameter("borrar_proveedor") != null) {
                        String id_proveedor = request.getParameter("borrar_proveedor");
                        if (funcion.valid_number(id_proveedor)) {
                            String sql = "delete from proveedores where id_proveedor=" + id_proveedor;
                            if (conexion_now.cargarConsulta(sql)) {
                                out.println(funcion.Redirect("Proveedors", "Proveedor borrado", "success", "administracion.jsp?proveedores"));
                            } else {
                                out.println(funcion.Redirect("Proveedores", "Ha ocurrido un error en la base de datos", "error", "administracion.jsp?proveedores"));
                            }
                        } else {
                            out.println(funcion.Redirect("Proveedores", "ID invalido", "warning", "administracion.jsp?proveedores"));
                        }
                    } else {
                        RequestDispatcher rd = request.getRequestDispatcher("administracion.jsp?proveedores");
                        rd.include(request, response);
                    }
                } else {
                    response.sendRedirect("login.jsp");
                }
            } else {
                response.sendRedirect("login.jsp");
            }
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
