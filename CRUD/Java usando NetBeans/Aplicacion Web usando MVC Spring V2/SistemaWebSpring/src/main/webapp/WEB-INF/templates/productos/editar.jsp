<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="../includes/admin_header.jsp"/>

<div class="panel contenedor panel-default">
    <div class="panel-heading">Editando al producto ${Producto.nombre}</div>
    <div class="panel-body">
        <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/productos/editar" commandName="Producto">
            <fieldset>
                <legend>Datos</legend>
                <form:hidden  path="id" />
                <div class="form-group" name="form-group-nombre">
                    <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
                    <div class="col-lg-10">
                        <form:input path="nombre" class="form-control" id="inputNombre" placeholder="Ingrese nombre" type="text"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-descripcion">
                    <label for="textArea" class="col-lg-2 control-label">Descripción</label>
                    <div class="col-lg-10">
                        <form:textarea path="descripcion" class="form-control" rows="3" id="textArea" placeholder="Ingrese descripción" />
                    </div>
                </div>
                <div class="form-group" name="form-group-precio">
                    <label for="inputPrecio" class="col-lg-2 control-label">Precio</label>
                    <div class="col-lg-10">
                        <form:input path="precio" class="form-control" id="inputPrecio" placeholder="Ingrese precio" type="text"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-proveedor">
                    <label for="select" class="col-lg-2 control-label">Proveedor</label>
                    <div class="col-lg-10">
                        <form:select class="form-control" id="select" path="id_proveedor">
                            <c:forEach items="${proveedores}" var="proveedor">
                                <form:option value="${proveedor.id}" label="${proveedor.nombre}" />
                            </c:forEach>
                        </form:select>
                    </div>
                </div>

                <div class="col-md-4 col-md-offset-4">
                    <div class="btn-group">
                        <div class="col-xs-6">
                            <button type="submit" class="btn btn-primary button_class center-block" name="editar_producto"><span class="glyphicon glyphicon-pencil right_space"></span>Editar</button>                        </div>
                        <div class="col-xs-6">
                            <a href="${context}/administracion/productos" class="btn btn-primary button_class center-block" role="button"><span class="glyphicon glyphicon-arrow-left right_space"></span>Volver</a>
                        </div>
                    </div>
                </div>

            </fieldset>
        </form:form>
    </div>
</div>

<jsp:include page="../includes/admin_footer.jsp"/>