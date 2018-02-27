<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 

<c:set var="context" value="${pageContext.request.contextPath}" />

<jsp:include page="../includes/mensaje_header.jsp"/>

<script>
    swal({
        title: "${mensaje.titulo}",
        text: "${mensaje.contenido}",
        type: "${mensaje.tipo}"
    }, function () {
        window.location = "${context}/${mensaje.url}";
            });
</script>

<jsp:include page="../includes/mensaje_footer.jsp"/>