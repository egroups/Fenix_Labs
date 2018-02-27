<%-- Written by Ismael Heredia in the year 2016 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<div class="panel contenedor panel-default">
    <div class="panel-heading">Productos encontrados : ${cantidad_productos_total}</div>
    <div class="panel-body">
        <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/productos/buscar" commandName="Buscador">
            <fieldset>
                <div class="form-group">
                    <label for="inputBuscar" class="col-lg-2 control-label">Nombre</label>
                    <div class="col-lg-10">
                        <form:input path="nombre_buscar" type="text" class="form-control" placeholder="Nombre"/>
                    </div>
                </div>
                <div class="form-group">
                    <button type="submit" name="busqueda" id="buscar_productos" class="btn btn-primary center-block">Buscar</button>
                </div>
            </fieldset>
        </form:form> 
    </div>
</div>

<c:if test="${BuscadorActivo==1}">
    <div class='panel contenedor panel-default'>
        <div class='panel-heading'>Productos encontrados : ${cantidad_productos_encontrados}</div>
        <div class='panel-body'>
            <c:choose>
                <c:when test="${cantidad_productos_encontrados > 0}">
                    <table class='table table-striped table-hover'>
                        <thead>
                            <tr>
                                <th class='fila_producto'>Nombre</th>
                                <th class='fila_producto'>Descripcion</th>
                                <th class='fila_producto'>Precio</th>
                                <th class='fila_producto'>Proveedor</th>
                                <th class='fila_producto'>Registro</th>
                                <th class='fila_producto'>Opción</th>
                            </tr>
                        </thead>
                        <tbody>
                            <c:forEach var="producto" items="${productos}">
                                <tr>
                                    <td class='filterable-cell fila_producto'>${producto.nombre_producto}</td>
                                    <td class='filterable-cell fila_producto'>${producto.descripcion}</td>
                                    <td class='filterable-cell fila_producto'>${producto.precio}</td>
                                    <td class='filterable-cell fila_producto'>${producto.nombre_empresa}</td>
                                    <td class='filterable-cell fila_producto'>${producto.fecha_registro}</td>
                                    <td class='filterable-cell fila_producto'><a href="${context}/administracion/productos/${producto.id_producto}/editar"><img src='${context}/resources/images/edit.png' title='Editar'></a> <a href="${context}/administracion/productos/${producto.id_producto}/borrar"><img src='${context}/resources/images/delete.png' title='Borrar'></a></td>
                                </tr>
                            </c:forEach>
                        </tbody>
                    </table>
                </c:when>
                <c:otherwise>
                    <center><b>No se encontraron productos</b></center>
                    </c:otherwise>
                </c:choose>
        </div>
    </div>
</c:if>