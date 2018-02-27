<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="../includes/admin_header.jsp"/>

<div class="panel contenedor panel-default">
    <div class="panel-heading">Editando al usuario ${AsignarUsuario.nombre}</div>
    <div class="panel-body">

        <form:form class="form-horizontal" role="form" method="post" action="${context}/administracion/usuarios/editar" commandName="AsignarUsuario">
            <fieldset>
                <legend>Datos</legend>
                <form:hidden  path="id" />
                <div class="form-group" name="form-group-nombre">
                    <label for="inputNombre" class="col-lg-2 control-label">Nombre</label>
                    <div class="col-lg-10">
                        <form:input path="nombre" class="form-control" id="inputNombre" placeholder="Ingrese nombre" type="text" readonly="true"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-clave">
                    <label for="inputClave" class="col-lg-2 control-label">Clave</label>
                    <div class="col-lg-10">
                        <input name="clave" class="form-control" id="inputClave" placeholder="Ingrese clave" type="password" readonly="true"/>
                    </div>
                </div>

                <div class="form-group" name="form-group-tipo">
                    <label for="select" class="col-lg-2 control-label">Tipo</label>
                    <div class="col-lg-10">
                        <form:select class="form-control" id="select" path="id_tipo">
                            <c:forEach items="${tipos}" var="tipo">
                                <form:option value="${tipo.id}" label="${tipo.nombre}" />
                            </c:forEach>
                        </form:select>
                    </div>
                </div>

                <div class="col-md-4 col-md-offset-4">
                    <div class="btn-group">
                        <div class="col-xs-6">
                            <button type="submit" class="btn btn-primary button_class center-block" name="editar_usuario"><span class="glyphicon glyphicon-pencil right_space"></span>Editar</button>                        </div>
                        <div class="col-xs-6">
                            <a href="${context}/administracion/usuarios" class="btn btn-primary button_class center-block" role="button"><span class="glyphicon glyphicon-arrow-left right_space"></span>Volver</a>
                        </div>
                    </div>
                </div>

            </fieldset>
        </form:form>
    </div>
</div>

<jsp:include page="../includes/admin_footer.jsp"/>