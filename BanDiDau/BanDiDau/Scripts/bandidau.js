$("body").on("click", ".bnt-box-continue", function () {
  
    $(this).addClass("enable");
    $(".box-info-customer").addClass("enable");
    $(".bnt-box-complete").removeClass("enable");
    $(".box-info-payment").removeClass("enable");
    $(".bnt-box-back").removeClass("enable");

    $(".plannerstep li").removeClass("firststep-on");
    $(".secondstep-off").addClass("firststep-on");

});
$("body").on("click", ".bnt-box-back", function () {
    $(this).addClass("enable");
    $(".bnt-box-continue").removeClass("enable");
    $(".box-info-customer").removeClass("enable");
    $(".bnt-box-complete").addClass("enable");
    $(".box-info-payment").addClass("enable");

    $(".plannerstep li").removeClass("firststep-on");
    $(".plannerstep li:first-child").addClass("firststep-on");

});