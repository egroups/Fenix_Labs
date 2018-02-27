<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="../includes/admin_header.jsp"/>

<div class="panel contenedor panel-default">
    <div class="panel-heading">Cambiar Clave</div>
    <div class="panel-body">

        <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/cuenta/cambiar_clave" commandName="CambiarClave">
            <fieldset>
                <legend>Datos</legend>

                <div class="form-group" name="form-group-username">
                    <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
                    <div class="col-lg-10">
                        <form:input path="nombre" class="form-control" id="inputNombre" placeholder="Ingrese nombre" type="text" value="${usuario}" readonly="true"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-anterior-password">
                    <label for="inputActualClave" class="col-lg-2 control-label">Actual clave</label>
                    <div class="col-lg-10">
                        <form:input path="clave" class="form-control" id="inputActualClave" placeholder="Ingrese clave" type="password"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-new-password">
                    <label for="inputNuevaClave" class="col-lg-2 control-label">Nueva clave</label>
                    <div class="col-lg-10">
                        <form:input path="nueva_clave" class="form-control" id="inputNuevo" placeholder="Ingrese nueva clave" type="password"/>
                    </div>
                </div>

                <div class="form-group">
                    <button type="submit" class="btn btn-primary center-block" name="cambiar_clave" id="cambiar_clave"><span class="glyphicon glyphicon-pencil right_space"></span>Cambiar</button>
                </div>

            </fieldset>
        </form:form>
    </div>
</div>

<jsp:include page="../includes/admin_footer.jsp"/>