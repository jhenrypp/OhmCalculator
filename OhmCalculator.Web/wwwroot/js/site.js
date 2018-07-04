// Write your JavaScript code.
var resistor = {
    recenterResistor: function () { $("#wrapper").css("left", (($(".container").width() - 417) / 2) + "px"); },
    calculate: function (bandAColor, bandBColor, bandCColor, bandDColor) {
        this.setColors("A", bandAColor);
        this.setColors("B", bandBColor);
        this.setColors("C", bandCColor);
        this.setColors("D", bandDColor);
        $.get("/api/ohmCalculator/" + bandAColor + "/" + bandBColor + "/" + bandCColor + "/" + bandDColor, function (data) {
            var s = data;
            if (data) {
                $("#dvResult").removeClass("hidden");
                $("#dvCalculator").addClass("hidden");
                $("#txtResistance").val(data.ohmResult);
                $("#txtTolerance").val(data.tolerance);
                $("#txtMinimum").val(data.minimum);
                $("#txtMaximum").val(data.maximum);
            }
        });
    
            
    },
    returnToCalculator: function () {
        $("#dvCalculator").removeClass("hidden");
        $("#dvResult").addClass("hidden");
    }, setColors: function (band, bandColor) {
        $("#band" + band.toUpperCase()).removeAttr("style");
        $("#band" + band.toUpperCase()).attr("style", "background: " + bandColor.toLowerCase() + " none repeat scroll 0% 0%;");
    }, setDropDownColor: function (band, bandColor) {
        $("#dlBand" + band).removeAttr("class");
        $("#dlBand" + band).attr("class", "form-control digit-picker ddlBand " + bandColor.toLowerCase());
    }, initColors: function () {
        this.setDropDownColor("A", $("#dlBandA").val());
        this.setDropDownColor("B", $("#dlBandB").val());
        this.setDropDownColor("C", $("#dlBandC").val());
        this.setDropDownColor("D", $("#dlBandD").val());
    }


};
 
$(window).resize(function () {
    resistor.recenterResistor();
});
$(document).ready(function () {
    resistor.initColors();
    resistor.recenterResistor();
    $(".form-control.digit-picker.ddlBand").change(function () {
            var id = this.id;
            resistor.setDropDownColor(id.replace("dlBand",""), $("#" + id).val());
    });
    $("#btnReturn").click(function () { resistor.returnToCalculator(); });
    $("#btnCalculate").click(function () {
        var bandAColor = $("#dlBandA").val();
        var bandBColor = $("#dlBandB").val();
        var bandCColor = $("#dlBandC").val();
        var bandDColor = $("#dlBandD").val();
        resistor.calculate(bandAColor, bandBColor, bandCColor, bandDColor);
        //console.log(bandAColor);
    });
    //$(".btnCalculate").click(function () {
    //    
    //});
});