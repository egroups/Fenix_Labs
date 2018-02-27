$(document).ready(function () {

    $('[data-toggle="tooltip"]').tooltip();

    $('#Ingreso').bootstrapValidator({
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
    });

    $('#Producto').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            nombre: {
                validators: {
                    notEmpty: {
                        message: 'El nombre es requerido'
                    }
                }
            },
            descripcion: {
                validators: {
                    notEmpty: {
                        message: 'La descripción es requerida'
                    }
                }
            },
            precio: {
                validators: {
                    notEmpty: {
                        message: 'El precio es requerido'
                    }
                }
            },
            id_proveedor: {
                validators: {
                    notEmpty: {
                        message: 'Debe seleccionar un proveedor'
                    }
                }
            }
        }
    });

    $('#Proveedor').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            nombre: {
                validators: {
                    notEmpty: {
                        message: 'El nombre es requerido'
                    }
                }
            },
            direccion: {
                validators: {
                    notEmpty: {
                        message: 'La dirección es requerida'
                    }
                }
            },
            telefono: {
                validators: {
                    notEmpty: {
                        message: 'El teléfono es requerido'
                    },
                    integer: {
                        message: 'El teléfono es inválido'
                    }
                }
            }
        }
    });

    $('#Usuario').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            nombre: {
                validators: {
                    notEmpty: {
                        message: 'El nombre es requerido'
                    }
                }
            },
            clave: {
                validators: {
                    notEmpty: {
                        message: 'La clave es requerida'
                    }
                }
            },
            id_tipo: {
                validators: {
                    notEmpty: {
                        message: 'Debe seleccionar un tipo de usuario'
                    }
                }
            }
        }
    });

    $('#AsignarUsuario').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            nombre: {
                validators: {
                    notEmpty: {
                        message: 'El nombre es requerido'
                    }
                }
            },
            id_tipo: {
                validators: {
                    notEmpty: {
                        message: 'Debe seleccionar un tipo de usuario'
                    }
                }
            }
        }
    });

    $('#CambiarUsuario').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            nombre: {
                validators: {
                    notEmpty: {
                        message: 'El usuario es requerido'
                    }
                }
            },
            nuevo_nombre: {
                validators: {
                    notEmpty: {
                        message: 'El nuevo usuario es requerido'
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
    });

    $('#CambiarClave').bootstrapValidator({
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            nombre: {
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
            },
            nueva_clave: {
                validators: {
                    notEmpty: {
                        message: 'La nueva clave es requerida'
                    }
                }
            }
        }
    });

});