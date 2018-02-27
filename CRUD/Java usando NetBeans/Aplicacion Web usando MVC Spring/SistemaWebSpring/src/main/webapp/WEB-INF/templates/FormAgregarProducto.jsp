<%-- Written by Ismael Heredia in the year 2016 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="includes/Header.jsp"/>

<jsp:include page="FormBuscadorProductos.jsp"/>

<div class="panel contenedor panel-default">
    <div class="panel-heading">Agregar Producto</div>
    <div class="panel-body">
        <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/productos/agregar" commandName="Producto">
            <fieldset>
                <legend>Datos</legend>
                <div class="form-group" name="form-group-nombre">
                    <label for="inputNombre" class="col-lg-2 control-label">Nombre producto</label>
                    <div class="col-lg-10">
                        <form:input path="nombre_producto" class="form-control" id="inputNombre" placeholder="Ingrese nombre producto" type="text"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-descripcion">
                    <label for="textArea" class="col-lg-2 control-label">Descripcion</label>
                    <div class="col-lg-10">
                        <form:textarea path="descripcion" class="form-control" rows="3" id="textArea" placeholder="Ingrese descripcion" />
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
                                <form:option value="${proveedor.id_proveedor}" label="${proveedor.nombre_empresa}" />
                            </c:forEach>
                        </form:select>
                    </div>
                </div>

                <div class="form-group">
                    <button type="submit" class="btn btn-primary center-block" name="agregar_producto" id="agregar_producto">Agregar</button>
                </div>

            </fieldset>
        </form:form>
    </div>
</div>

<jsp:include page="includes/Footer.jsp"/>