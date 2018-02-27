<%-- Written by Ismael Heredia in the year 2017 --%>

<%@ taglib uri="http://www.springframework.org/tags" prefix="spring"%>  
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>  
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%> 
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Administración</title>

        <!-- Bootstrap -->

        <c:set var="context" value="${pageContext.request.contextPath}" />

        <link href="${context}/resources/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>
        <link href="${context}/resources/css/style.css" rel="stylesheet"/>
        <link href="${context}/resources/css/bootstrapValidator.css" rel="stylesheet"/>
        <link href="${context}/resources/dist/sweetalert.css" rel="stylesheet"/>
        
        <script src="${context}/resources/js/jquery-3.2.1.js"></script> 
        <script src="${context}/resources/bootstrap/js/bootstrap.js"></script>
        <script src="${context}/resources/js/bootstrapValidator.js"></script>
        <script src="${context}/resources/dist/sweetalert-dev.js"></script>
        <script src="${context}/resources/js/app.js"></script>

        <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
              <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
              <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
            <![endif]-->
    </head>
    <body>