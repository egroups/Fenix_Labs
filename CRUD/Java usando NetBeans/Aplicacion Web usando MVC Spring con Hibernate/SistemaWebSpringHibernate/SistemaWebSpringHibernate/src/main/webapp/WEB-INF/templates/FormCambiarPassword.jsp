<%-- Written by Ismael Heredia in the year 2016 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="includes/Header.jsp"/>

<div class="panel contenedor panel-default">
    <div class="panel-heading">Cambiar Password</div>
    <div class="panel-body">

        <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/cuenta/cambiar_password" commandName="CambiarPassword">
            <fieldset>
                <legend>Datos</legend>

                <div class="form-group" name="form-group-username">
                    <label for="inputNombre" class="col-lg-2 control-label">Usuario</label>
                    <div class="col-lg-10">
                        <form:input path="nombre_usuario" class="form-control" id="inputUsuario" placeholder="Ingrese nombre usuario" type="text" value="${usuario}" readonly="true"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-anterior-password">
                    <label for="inputActual" class="col-lg-2 control-label">Actual contraseña</label>
                    <div class="col-lg-10">
                        <form:input path="password" class="form-control" id="inputAnterior" placeholder="Ingrese password" type="password"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-new-password">
                    <label for="inputActual" class="col-lg-2 control-label">Nueva contraseña</label>
                    <div class="col-lg-10">
                        <form:input path="nuevo_password" class="form-control" id="inputNuevo" placeholder="Ingrese nuevo password" type="password"/>
                    </div>
                </div>

                <div class="form-group">
                    <button type="submit" class="btn btn-primary center-block" name="cambiar_pass" id="cambiar_pass">Cambiar</button>
                </div>

            </fieldset>
        </form:form>
    </div>
</div>

<jsp:include page="includes/Footer.jsp"/>