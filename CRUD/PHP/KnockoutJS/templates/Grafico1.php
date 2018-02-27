<?php  

include_once("../includes/ABM.php");

if(!verificar_cookie()) {
  header('Location: ../index.php');
}

?>

<div class="panel contenedor panel-default">
    <div class="panel-heading">Grafico 1</div>
    <div class="panel-body">

<?php

include_once("../includes/ClaseConexion.php");

$consulta = "";

$conexion_now = new Conexion(); 
$conexion_now->abrir_conexion();
$conexion = $conexion_now->retornar_conexion();

$consulta = mysqli_query($conexion,"select nombre_producto,precio from productos");

$cantidad = mysqli_num_rows($consulta);

$titulo    = "Reporte de productos y sus precios";

$ids        = array();
$textos       = array();
$datos = array();

while ($resultado = mysqli_fetch_array($consulta)) {
    $nombre_producto = $resultado[0];
    $precio = $resultado[1];
    array_push($textos,$nombre_producto);
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

$conexion_now->cerrar_conexion();
                     
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