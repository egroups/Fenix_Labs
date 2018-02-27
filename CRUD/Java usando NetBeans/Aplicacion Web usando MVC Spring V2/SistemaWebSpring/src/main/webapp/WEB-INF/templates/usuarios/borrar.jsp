<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="../includes/admin_header.jsp"/>

<div class="jumbotron">
    <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/usuarios/borrar" commandName="Usuario">
        <fieldset>
            <form:hidden  path="id" />
            <div class="col-md-4 col-md-offset-4">
                <h1 class="text-center">Eliminacíon</h1>
                <p class="text-center">¿Estás seguro que deseas eliminar al usuario ${Usuario.nombre} ?</p>
                <div class="col-xs-6 text-left">
                    <button type="submit" name="borrar_producto" class="btn btn-danger btn-block"><span class="glyphicon glyphicon-trash right_space"></span>Borrar</button>
                </div>
                <div class="col-xs-6 text-right">
                    <a class="btn btn-primary btn-block" href="${context}/administracion/usuarios"><span class="glyphicon glyphicon-arrow-left right_space"></span>Volver</a>
                </div>
            </div>
        </fieldset>
    </form:form>
</div>

<jsp:include page="../includes/admin_footer.jsp"/>