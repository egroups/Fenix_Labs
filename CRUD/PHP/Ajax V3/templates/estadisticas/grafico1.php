<?php  

// Written by Ismael Heredia in the year 2017

include_once("../../includes/Funciones.php");
include_once("../../includes/Conexion.php");

if(!verificarCookie()) {
  exit;
}

?>

<div class="panel contenedor panel-default">
    <div class="panel-heading">Gráfico 1</div>
    <div class="panel-body">

<?php

$conexion = new Conexion();
$conexion->abrir_conexion();
$conn = $conexion->retornar_conexion();

$sql = $conn->prepare('SELECT nombre,precio FROM productos');
$sql->execute();

$resultado = $sql->fetchAll();

$titulo    = "Reporte de productos y sus precios";

$ids        = array();
$textos       = array();
$datos = array();

foreach ($resultado as $fila) {
    $nombre = $fila['nombre'];
    $precio = $fila['precio'];
    array_push($textos,$nombre);
    array_push($datos,$precio);
}

$nombres = array();
$series  = array();

for ($i = 0; $i <= count($textos) - 1; $i++) {
    
    $nombre = $textos[$i];
    $valor  = $datos[$i];
    $serie  = array(
        'name' => $nombre,
        'y' => (int) $valor
    );
    array_push($nombres, $nombre);
    array_push($series, $serie);
}

$conexion->cerrar_conexion();
                     
?> 

<script type="text/javascript">
$(function () {
    $('#grafico1').highcharts({
        chart: {
            type: 'bar'
        },
        title: {
            text: '<?php echo $titulo; ?>'
        },
        xAxis: {
            categories: <?php echo json_encode($nombres); ?>,
            title: {
            text: 'Productos'
            }
        },
                
        yAxis: {
            min: 0,
            title: {
                text: 'Precios',
                align: 'high'
            },
            labels: {
                overflow: 'justify'
            }
        },
        tooltip: {
        useHTML: true,
        formatter: function() {
            return '<b>Precio : </b>$'+this.point.y;
        }},
        plotOptions: {
        
        series: {
            dataLabels:{
                //enabled:true,
            },events: {
                legendItemClick: function () {
                        return false; 
                }
            }
        }
          },
        legend: {
            reversed: true
        },
        credits: {
            enabled: false
        },
        series: [{
        name:'Precios',
        data: <?php
            echo json_encode($series);
?>
 }]
    });
});
</script>    

<div id="grafico1" style="width: 800px; height: 400px;"></div>

</div>
</div>