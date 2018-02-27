<%-- Written by Ismael Heredia in the year 2016 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="includes/Header.jsp"/>

<jsp:include page="FormBuscadorProveedores.jsp"/>

<div class="panel contenedor panel-default">
    <div class="panel-heading">Agregar Proveedor</div>
    <div class="panel-body">
        <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/proveedores/agregar" commandName="Proveedor">
            <fieldset>
                <legend>Datos</legend>

                <div class="form-group" name="form-group-nombre">
                    <label for="inputNombre" class="col-lg-2 control-label">Nombre empresa</label>
                    <div class="col-lg-10">
                        <form:input path="nombre_empresa" class="form-control" id="inputNombre" placeholder="Ingrese nombre empresa" type="text"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-direccion">
                    <label for="inputDireccion" class="col-lg-2 control-label">Direccion</label>
                    <div class="col-lg-10">
                        <form:input path="direccion" class="form-control" id="inputDireccion" placeholder="Ingrese direccion" type="text"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-telefono">
                    <label for="inputTelefono" class="col-lg-2 control-label">Telefono</label>
                    <div class="col-lg-10">
                        <form:input path="telefono" class="form-control" id="inputTelefono" placeholder="Ingrese telefono" type="text"/>
                    </div>
                </div>

                <div class="form-group">
                    <button type="submit" class="btn btn-primary center-block" name="agregar_proveedor" id="agregar_proveedor">Agregar</button>
                </div>

            </fieldset>
        </form:form>
    </div>
</div>

<jsp:include page="includes/Footer.jsp"/>