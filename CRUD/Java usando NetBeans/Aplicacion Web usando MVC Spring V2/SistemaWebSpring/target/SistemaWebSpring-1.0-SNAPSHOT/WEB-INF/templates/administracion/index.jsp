<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<jsp:include page="../includes/admin_header.jsp"/>

<center>
    <h1>Bienvenido a la administración ${tipo} ${usuario_logeado}</h1>
</center>

${mensaje}

<jsp:include page="../includes/admin_footer.jsp"/>