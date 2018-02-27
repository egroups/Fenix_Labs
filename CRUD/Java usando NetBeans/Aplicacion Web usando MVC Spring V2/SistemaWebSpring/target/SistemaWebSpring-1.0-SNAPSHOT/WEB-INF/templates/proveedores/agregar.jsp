<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="../includes/admin_header.jsp"/>

<div class="panel contenedor panel-default">
    <div class="panel-heading">Agregar Proveedor</div>
    <div class="panel-body">
        <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/proveedores/agregar" commandName="Proveedor">
            <fieldset>
                <legend>Datos</legend>

                <div class="form-group" name="form-group-nombre">
                    <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
                    <div class="col-lg-10">
                        <form:input path="nombre" class="form-control" id="inputNombre" placeholder="Ingrese nombre" type="text"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-direccion">
                    <label for="inputDireccion" class="col-lg-2 control-label">Dirección</label>
                    <div class="col-lg-10">
                        <form:input path="direccion" class="form-control" id="inputDireccion" placeholder="Ingrese dirección" type="text"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-telefono">
                    <label for="inputTelefono" class="col-lg-2 control-label">Teléfono</label>
                    <div class="col-lg-10">
                        <form:input path="telefono" class="form-control" id="inputTelefono" placeholder="Ingrese teléfono" type="text"/>
                    </div>
                </div>

                <div class="col-md-4 col-md-offset-4">
                    <div class="btn-group">
                        <div class="col-xs-6">
                            <button type="submit" class="btn btn-primary button_class center-block" name="agregar_proveedor"><span class="glyphicon glyphicon-plus right_space"></span>Agregar</button>
                        </div>
                        <div class="col-xs-6">
                            <a href="${context}/administracion/proveedores" class="btn btn-primary button_class center-block" role="button"><span class="glyphicon glyphicon-arrow-left right_space"></span>Volver</a>
                        </div>
                    </div>
                </div>

            </fieldset>
        </form:form>
    </div>
</div>

<jsp:include page="../includes/admin_footer.jsp"/>