<%-- Written by Ismael Heredia in the year 2016 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<div class="panel contenedor panel-default">
    <div class="panel-heading">Usuarios encontrados : ${cantidad_usuarios_total}</div>
    <div class="panel-body">
        <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/usuarios/buscar" commandName="Buscador">
            <fieldset>
                <div class="form-group">
                    <label for="inputBuscar" class="col-lg-2 control-label">Nombre</label>
                    <div class="col-lg-10">
                        <form:input path="nombre_buscar" type="text" class="form-control" placeholder="Nombre"/>
                    </div>
                </div>
                <div class="form-group">
                    <button type="submit" name="busqueda" id="buscar_proveedores" class="btn btn-primary center-block">Buscar</button>
                </div>
            </fieldset>
        </form:form> 
    </div>
</div>

<c:if test="${BuscadorActivo==1}">
    <div class='panel contenedor panel-default'>
        <div class='panel-heading'>Usuarios encontrados : ${cantidad_usuarios_encontrados}</div>
        <div class='panel-body'>
            <c:choose>
                <c:when test="${cantidad_usuarios_encontrados > 0}">
                    <table class='table table-striped table-hover'>
                        <thead>
                            <tr>
                                <th class='fila_usuario'>Nombre</th>
                                <th class='fila_usuario'>Tipo</th>
                                <th class='fila_usuario'>Registro</th>
                                <th class='fila_usuario'>Opción</th>
                            </tr>
                        </thead>
                        <tbody>
                            <c:forEach var="usuario" items="${usuarios}">
                                <tr>
                                    <td class='filterable-cell fila_usuario'>${usuario.nombre}</td>
                                    <td class='filterable-cell fila_usuario'>${usuario.nombre_tipo}</td>
                                    <td class='filterable-cell fila_usuario'>${usuario.fecha_registro}</td>
                                    <td class='filterable-cell fila_usuario'><a href="${context}/administracion/usuarios/${usuario.id_usuario}/editar"><img src='${context}/resources/images/edit.png' title='Editar'></a> <a href="${context}/administracion/usuarios/${usuario.id_usuario}/borrar"><img src='${context}/resources/images/delete.png' title='Borrar'></a></td>
                                </tr>
                            </c:forEach>
                        </tbody>
                    </table>
                </c:when>
                <c:otherwise>
                    <center><b>No se encontraron usuarios</b></center>
                    </c:otherwise>
                </c:choose>
        </div>
    </div>
</c:if>