<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="../includes/login_header.jsp"/>

<div class="panel login panel-default">
    <div class="panel-heading">Login</div>
    <div class="panel-body">

        <form:form class="form-horizontal" role="form" method="post" action="${context}/IngresoUsuario" commandName="Ingreso">
            <fieldset>
                <legend>Datos</legend>
                <div class="form-group" name="form-group-username">
                    <label for="inputTexto1" class="col-lg-2 control-label">Usuario</label>
                    <div class="col-lg-10">
                        <form:input path="usuario" class="form-control" id="inputUsuario" name="usuario" placeholder="Ingrese usuario" type="text"/>
                    </div>
                </div>
                <div class="form-group" name="form-group-password">
                    <label for="inputTexto2" class="col-lg-2 control-label">Clave</label>
                    <div class="col-lg-10">
                        <form:input path="clave" class="form-control" id="inputClave" name="clave" placeholder="Ingrese clave" type="password"/>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-4 col-md-offset-4">
                        <button type="submit" name="Ingresar" id="ingresar" class="btn btn-primary btn-block">Ingresar</button>
                    </div>
                </div>
            </fieldset>
        </form:form>       

    </div>
</div>

</div>

${mensaje}

<jsp:include page="../includes/login_footer.jsp"/>