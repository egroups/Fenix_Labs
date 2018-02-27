// Written by Ismael Heredia in the year 2016

package sistema.models;

public class Mensaje {

    String titulo;
    String contenido;
    String tipo;
    String url;

    public String getTitulo() {
        return titulo;
    }

    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }

    public String getContenido() {
        return contenido;
    }

    public void setContenido(String contenido) {
        this.contenido = contenido;
    }

    public String getTipo() {
        return tipo;
    }

    public void setTipo(String tipo) {
        this.tipo = tipo;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public Mensaje() {
    }

    public Mensaje(String titulo, String contenido, String tipo, String url) {
        this.titulo = titulo;
        this.contenido = contenido;
        this.tipo = tipo;
        this.url = url;
    }

    @Override
    public String toString() {
        return "Mensaje{" + "titulo=" + titulo + ", contenido=" + contenido + ", tipo=" + tipo + ", url=" + url + '}';
    }

}
