<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="../includes/admin_header.jsp"/>

<div class="panel contenedor panel-default">
    <div class="panel-body">
        <br/>
        <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/productos/listar" commandName="Buscador">
            <fieldset>
                <div class="form-group">
                    <div class="col-lg-2">
                        <a href="${context}/administracion/productos/agregar" class="btn btn-primary btn-block" role="button"><span class="glyphicon glyphicon-plus"></span> Agregar</a>
                    </div>
                    <div class="col-lg-9">                   
                        <form:input path="nombre_buscar" type="text" class="form-control" placeholder="Ingrese nombre a buscar"/>
                    </div>
                    <div class="col-lg-1">
                        <button type="submit" name="busqueda" class="btn btn-primary btn-block"><span class="glyphicon glyphicon-search"></button>
                    </div>
                </div>
            </fieldset>
        </form:form> 
    </div>
</div>

<div class='panel contenedor panel-default'>
    <div class='panel-heading'>Productos encontrados : ${cantidad}</div>
    <div class='panel-body'>
        <c:choose>
            <c:when test="${cantidad > 0}">
                <table class='table table-striped table-hover'>
                    <thead>
                        <tr>
                            <th class='fila_producto'>Nombre</th>
                            <th class='fila_producto'>Descripción</th>
                            <th class='fila_producto'>Precio</th>
                            <th class='fila_producto'>Proveedor</th>
                            <th class='fila_producto'>Registro</th>
                            <th class='fila_producto'>Opción</th>
                        </tr>
                    </thead>
                    <tbody>
                        <c:forEach items="${productos}" var="producto">
                            <tr>
                                <td class='filterable-cell fila_producto'>${producto.nombre}</td>
                                <td class='filterable-cell fila_producto'>${producto.descripcion}</td>
                                <td class='filterable-cell fila_producto'>${producto.precio}</td>
                                <td class='filterable-cell fila_producto'>${producto.proveedor.nombre}</td>
                                <td class='filterable-cell fila_producto'>${producto.fecha_registro}</td>
                                <td class='filterable-cell fila_producto'>
                                    <a href="${context}/administracion/productos/${producto.id}/editar">
                                        <img data-toggle="tooltip" src='${context}/resources/images/edit.png' title='Editar'>
                                    </a>
                                    <a href="${context}/administracion/productos/${producto.id}/borrar">
                                        <img data-toggle="tooltip" src='${context}/resources/images/delete.png' title='Borrar'>
                                    </a>
                                </td>
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

<jsp:include page="../includes/admin_footer.jsp"/>