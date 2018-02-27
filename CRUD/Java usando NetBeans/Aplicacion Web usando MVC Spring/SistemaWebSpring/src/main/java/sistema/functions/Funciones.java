// Written by Ismael Heredia in the year 2016
package sistema.functions;

import java.io.UnsupportedEncodingException;
import java.nio.charset.StandardCharsets;
import java.security.MessageDigest;
import java.text.SimpleDateFormat;
import java.util.Base64;
import java.util.Calendar;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;
import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import sistema.dao.UsuarioDAO;

public class Funciones {

    public boolean valid_cookie(HttpServletRequest request) {
        boolean respuesta = false;
        try {
            ApplicationContext context
                    = new ClassPathXmlApplicationContext("Spring-Module.xml");
            UsuarioDAO usuarioDAO = (UsuarioDAO) context.getBean("UsuarioDAO");
            Cookie[] cookies = request.getCookies();
            for (Cookie cookie : cookies) {
                if (cookie.getName().equals("user_login")) {
                    String cookie_content = base64_decode(cookie.getValue());
                    Pattern regex1 = null;
                    Matcher regex2 = null;
                    regex1 = Pattern.compile("(.*)-(.*)");
                    regex2 = regex1.matcher(cookie_content);
                    if (regex2.find()) {
                        String usuario = regex2.group(1);
                        String password = regex2.group(2);
                        if (!"".equals(usuario) && !"".equals(password)) {
                            if (usuarioDAO.ingreso_usuario(usuario, password)) {
                                respuesta = true;
                            } else {
                                respuesta = false;
                            }
                        } else {
                            respuesta = false;
                        }
                    } else {
                        respuesta = false;
                    }
                }
            }
        } catch (Exception e) {
            respuesta = false;
        }
        return respuesta;
    }

    public String get_username_cookie(HttpServletRequest request) {
        String respuesta = "";
        try {
            ApplicationContext context
                    = new ClassPathXmlApplicationContext("Spring-Module.xml");
            UsuarioDAO usuarioDAO = (UsuarioDAO) context.getBean("UsuarioDAO");
            Cookie[] cookies = request.getCookies();
            for (Cookie cookie : cookies) {
                if (cookie.getName().equals("user_login")) {
                    String cookie_content = base64_decode(cookie.getValue());
                    Pattern regex1 = null;
                    Matcher regex2 = null;
                    regex1 = Pattern.compile("(.*)-(.*)");
                    regex2 = regex1.matcher(cookie_content);
                    if (regex2.find()) {
                        String usuario = regex2.group(1);
                        String password = regex2.group(2);
                        if (!"".equals(usuario) && !"".equals(password)) {
                            if (usuarioDAO.ingreso_usuario(usuario, password)) {
                                respuesta = usuario;
                            } else {
                                respuesta = "desconocido";
                            }
                        } else {
                            respuesta = "desconocido";
                        }
                    } else {
                        respuesta = "desconocido";
                    }
                }
            }
        } catch (Exception e) {
            respuesta = "desconocido";
        }
        return respuesta;
    }

    public boolean validar_cookie_admin(HttpServletRequest request) {
        boolean respuesta = false;
        try {
            ApplicationContext context
                    = new ClassPathXmlApplicationContext("Spring-Module.xml");
            UsuarioDAO usuarioDAO = (UsuarioDAO) context.getBean("UsuarioDAO");
            Cookie[] cookies = request.getCookies();
            for (Cookie cookie : cookies) {
                if (cookie.getName().equals("user_login")) {
                    String cookie_content = base64_decode(cookie.getValue());
                    Pattern regex1 = null;
                    Matcher regex2 = null;
                    regex1 = Pattern.compile("(.*)-(.*)");
                    regex2 = regex1.matcher(cookie_content);
                    if (regex2.find()) {
                        String usuario = regex2.group(1);
                        String password = regex2.group(2);
                        if (!"".equals(usuario) && !"".equals(password)) {
                            if (usuarioDAO.ingreso_usuario(usuario, password)) {
                                if (usuarioDAO.es_admin(usuario)) {
                                    respuesta = true;
                                } else {
                                    respuesta = false;
                                }
                            } else {
                                respuesta = false;
                            }
                        } else {
                            respuesta = false;
                        }
                    } else {
                        respuesta = false;
                    }
                }
            }
        } catch (Exception e) {
            respuesta = false;
        }
        return respuesta;
    }

    public String base64_encode(String text) {
        String encoded = "";
        byte[] data;
        try {
            data = text.getBytes("UTF-8");
            encoded = Base64.getEncoder().encodeToString(data);
        } catch (UnsupportedEncodingException ex) {
            //
        }
        return encoded;
    }

    public String base64_decode(String text) {
        byte[] data = Base64.getDecoder().decode(text);
        String decoded = new String(data, StandardCharsets.UTF_8);
        return decoded;
    }

    public String md5_encode(String text) {
        // Credits : Based on http://www.avajava.com/tutorials/lessons/how-do-i-generate-an-md5-digest-for-a-string.html
        StringBuffer string_now = null;
        try {
            MessageDigest generate = MessageDigest.getInstance("MD5");
            generate.update(text.getBytes());
            byte[] result = generate.digest();
            string_now = new StringBuffer();
            for (byte line : result) {
                string_now.append(String.format("%02x", line & 0xff));
            }
        } catch (Exception e) {
            //
        }
        return string_now.toString();
    }

    public static boolean valid_number(String str) {
        try {
            double d = Double.parseDouble(str);
        } catch (NumberFormatException nfe) {
            return false;
        }
        return true;
    }

    public String fecha_del_dia() {
        String fecha = new SimpleDateFormat("yyyy-MM-dd").format(Calendar.getInstance().getTime());
        return fecha;
    }

}
