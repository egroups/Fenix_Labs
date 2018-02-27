$(document).ready(function(){

	$('[data-toggle="tooltip"]').tooltip(); 

	$('#loginForm').bootstrapValidator({
	    feedbackIcons: {
	        valid: 'glyphicon glyphicon-ok',
	        invalid: 'glyphicon glyphicon-remove',
	        validating: 'glyphicon glyphicon-refresh'
	    },
	    fields: {
	        usuario: {
	            validators: {
	                notEmpty: {
	                    message: 'El usuario es requerido'
	                }
	            }
	        },
	        clave: {
	            validators: {
	                notEmpty: {
	                    message: 'La clave es requerida'
	                }
	            }
	        }
	    }
	})
	.on('success.form.bv', function(e) {
	    $('#success_message').slideDown({ opacity: "show" }, "slow") // Do something ...
	        $('#loginForm').data('bootstrapValidator').resetForm();
	});

});