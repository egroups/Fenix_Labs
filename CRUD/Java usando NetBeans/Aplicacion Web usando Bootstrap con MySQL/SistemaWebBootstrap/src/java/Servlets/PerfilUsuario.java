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

@WebServlet(name = "PerfilUsuario", urlPatterns = {"/PerfilUsuario"})
public class PerfilUsuario extends HttpServlet {

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

                    if (request.getParameter("cambiar_user") != null) {

                        String username = request.getParameter("nombre_usuario");
                        String password = request.getParameter("password");
                        String new_username = request.getParameter("nuevo_usuario");

                        if (!"".equals(username) && !"".equals(password) && !"".equals(new_username)) {
                            String password_encoded = funcion.md5_encode(password);
                            if (conexion_now.ingreso_usuario(username, password_encoded)) {
                                if (conexion_now.comprobar_existencia_usuario_editar(new_username)) {
                                    out.println(funcion.Redirect("Cambiar Usuario", "El usuario " + new_username + " ya existe", "warning", "administracion.jsp?cambiar_usuario"));
                                } else {
                                    String sql = "update usuarios set usuario='" + new_username + "' where usuario='" + username + "'";
                                    if (conexion_now.cargarConsulta(sql)) {
                                        out.println(funcion.Redirect("Cambiar Usuario", "Nombre de usuario cambiado , se debe reiniciar el sistema", "success", "Login?LogOut"));
                                    } else {
                                        out.println(funcion.Redirect("Cambiar Usuario", "Ha ocurrido un error en la base de datos", "error", "administracion.jsp?cambiar_usuario"));
                                    }
                                }
                            } else {
                                out.println(funcion.Redirect("Cambiar Usuario", "Login incorrecto", "error", "administracion.jsp?cambiar_usuario"));
                            }
                        } else {
                            out.println(funcion.Redirect("Cambiar Usuario", "Faltan datos", "warning", "administracion.jsp?cambiar_usuario"));
                        }

                    } else if (request.getParameter("cambiar_pass") != null) {

                        String username = request.getParameter("nombre_usuario");
                        String password = request.getParameter("password");
                        String new_password = request.getParameter("nuevo_password");

                        if (!"".equals(username) && !"".equals(password) && !"".equals(new_password)) {
                            String password_encoded = funcion.md5_encode(password);
                            String new_password_encoded = funcion.md5_encode(new_password);
                            if (conexion_now.ingreso_usuario(username, password_encoded)) {
                                String sql = "update usuarios set clave='" + new_password_encoded + "' where usuario='" + username + "'";
                                if (conexion_now.cargarConsulta(sql)) {
                                    out.println(funcion.Redirect("Cambiar Password", "Password de usuario cambiado , se debe reiniciar el sistema", "success", "Login?LogOut"));
                                } else {
                                    out.println(funcion.Redirect("Cambiar Password", "Ha ocurrido un error en la base de datos", "error", "administracion.jsp?cambiar_password"));
                                }
                            } else {
                                out.println(funcion.Redirect("Cambiar Password", "Login incorrecto", "error", "administracion.jsp?cambiar_password"));
                            }
                        } else {
                            out.println(funcion.Redirect("Cambiar Password", "Faltan datos", "warning", "administracion.jsp?cambiar_password"));
                        }

                    } else {
                        RequestDispatcher rd = request.getRequestDispatcher("administracion.jsp");
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
