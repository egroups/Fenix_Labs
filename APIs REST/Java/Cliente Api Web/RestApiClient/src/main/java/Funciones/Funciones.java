// Written by Ismael Heredia in the year 2016
package Funciones;

import Modelo.Proveedor;
import Vista.FormHome;
import com.sun.jersey.api.client.Client;
import com.sun.jersey.api.client.ClientResponse;
import com.sun.jersey.api.client.WebResource;
import java.io.StringReader;
import java.security.MessageDigest;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.DefaultComboBoxModel;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.xpath.XPath;
import javax.xml.xpath.XPathFactory;
import org.json.JSONArray;
import org.json.JSONObject;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;

public class Funciones {

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

    public String getApi(String url, String type) {
        Client cliente = Client.create();
        WebResource webResource = cliente
                .resource(url);
        ClientResponse clientResponse = webResource.accept("application/" + type)
                .get(ClientResponse.class);
        if (clientResponse.getStatus() != 201 && clientResponse.getStatus() != 200) {
            throw new RuntimeException("Failed : HTTP error code : "
                    + clientResponse.getStatus());
        }
        String output = clientResponse.getEntity(String.class);
        return output;
    }

    public String postApi(String url, String type, String json) {
        Client client = Client.create();

        WebResource webResource = client
                .resource(url);

        String input = json;

        ClientResponse clientResponse = webResource.type("application/" + type)
                .post(ClientResponse.class, input);

        if (clientResponse.getStatus() != 201) {
            throw new RuntimeException("Failed : HTTP error code : "
                    + clientResponse.getStatus());
        }

        String output = clientResponse.getEntity(String.class);
        return output;
    }

    public String putApi(String url, String type, String json) {
        Client client = Client.create();

        WebResource webResource = client
                .resource(url);

        String input = json;

        ClientResponse clientResponse = webResource.type("application/" + type)
                .put(ClientResponse.class, input);

        if (clientResponse.getStatus() != 201) {
            throw new RuntimeException("Failed : HTTP error code : "
                    + clientResponse.getStatus());
        }

        String output = clientResponse.getEntity(String.class);
        return output;
    }

    public String deleteApi(String url, String type, String json) {
        Client client = Client.create();

        WebResource webResource = client
                .resource(url);

        String input = json;

        ClientResponse clientResponse = webResource.type("application/" + type)
                .delete(ClientResponse.class);

        if (clientResponse.getStatus() != 201) {
            throw new RuntimeException("Failed : HTTP error code : "
                    + clientResponse.getStatus());
        }

        String output = clientResponse.getEntity(String.class);
        return output;
    }

    public String getStringTagXML(Element element, String name) {
        String value = null;
        NodeList node_list = element.getElementsByTagName(name);
        if (node_list != null && node_list.getLength() > 0) {
            Element extract_element = (Element) node_list.item(0);
            value = extract_element.getFirstChild().getNodeValue();
        }
        return value;
    }

    public int getIntTagXML(Element element, String tag) {
        return Integer.parseInt(getStringTagXML(element, tag));
    }

    public double getDoubleTagXML(Element element, String tag) {
        return Double.parseDouble(getStringTagXML(element, tag));
    }

    public String cargarNombreProveedor(int id_proveedor, String url, String tipo) {

        String nombre_empresa = "";
        String contenido = getApi(url + "/rest/" + tipo + "/proveedores/" + id_proveedor, tipo);

        ArrayList proveedores = new ArrayList();

        if ("json".equals(tipo)) {

            JSONObject json_object = new JSONObject(contenido);
            nombre_empresa = json_object.getString("nombre_empresa");

        } else {

            try {
                DocumentBuilderFactory document = DocumentBuilderFactory.newInstance();

                DocumentBuilder builder = document.newDocumentBuilder();

                InputSource stream = new InputSource();

                stream.setCharacterStream(new StringReader(contenido));

                Document dom = builder.parse(stream);
                XPathFactory factory = XPathFactory.newInstance();
                XPath xpath = factory.newXPath();

                nombre_empresa = (String) xpath.evaluate("//proveedor/nombre_empresa", dom);

            } catch (Exception ex) {
                Logger.getLogger(FormHome.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
        return nombre_empresa;
    }

    public String getMessageJson(String contenido) {
        JSONObject json_object = new JSONObject(contenido);
        return json_object.getString("message");
    }

    public boolean getStatusJson(String contenido) {
        JSONObject json_object = new JSONObject(contenido);
        return json_object.getBoolean("success");
    }

}
