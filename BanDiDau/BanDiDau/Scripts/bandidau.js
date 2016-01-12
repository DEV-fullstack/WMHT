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
//jquery on search dialog

//function search_key() {
//    $('#search-country').keyup(function () {
//        var textValue = $(this).val();
//        search_country(textValue);
//    });
//}
//function search_country(textValue) {
//    $.ajax({
//        url: "/Home/CountryLookup?textValue=" + textValue,
//        type: "GET",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            var str = '';
//            $.each(result, function (key, item) {
//            });
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });

//    return false;
//}
var rooms = 0;
function add_count(room) {
    var currentValue = parseInt($("#adultCount" + room).text(), 10);
    if (currentValue < 5) {
        var newValue = currentValue + 1;
        $("#adultCount" + room).html(newValue);
        $("#adultCounth" + room).val(newValue);
    }
    if (currentValue > 1) {
        $("#extrabed_room" + room).addClass('hide');
    }
}
function deduct_count(room) {
    var currentValue = parseInt($("#adultCount" + room).text(), 10);
    if (currentValue > 1) {
        var newValue = currentValue - 1;
        $("#adultCount" + room).html(newValue);
        $("#adultCounth" + room).val(newValue);
    }
    if (currentValue < 4) {
        $("#extrabed_room" + room).removeClass('hide');
    }
}
function add_child_count(room) {
    var currentValue = parseInt($("#childCount" + room).text(), 10);
    if (currentValue < 2) {
        var newValue = currentValue + 1;
        $("#childCount" + room).html(newValue);
        $("#childCounth" + room).val(newValue);
    }
    childChange(room);
}
function deduct_child_count(room) {
    var currentValue = parseInt($("#childCount" + room).text(), 10);
    if (currentValue > 0) {
        var newValue = currentValue - 1;
        $("#childCount" + room).html(newValue);
        $("#childCounth" + room).val(newValue);
    }
    childChange(room);
}
function add_rooms() {
    if (rooms < 2) {
        rooms++;
        //var label=rooms+1;
        $('#roomdiv').append('<div id="rooms' + rooms + '" >' +
        '<div class="row">' +
        '<div class="form-group col-md-2 col-sm-3 col-xs-12 text-center" style="padding-top:0px;">' +
                    '<label>Room</label><span class="badge" style="padding:11px 15px;border-radius:20px;background-color: #999999">' + (rooms + 1) + '</span>' +
                '</div>' +
                '<div class="rows">' +
                '<div id="adults"' + rooms + '" class="form-group col-md-2 col-sm-3 col-xs-6">' +
                        '<label>Adults</label>' +
                        '<div class="btn-group" data-toggle="buttons">' +
                           '<label class="btn btn-primary" style="border-top-left-radius:2px; border-bottom-left-radius:2px;" onclick="deduct_count(' + rooms + ')">' +
                              '<span>-</span>' +
                           '</label>' +
                           '<label class="btn button_white">' +
                           '<span id="adultCount' + rooms + '" >2</span>' +
                           '<input type="hidden" id="adultCounth' + rooms + '" name="adults[]"   value="2" />' +
                           '</label>' +
                           '<label class="btn btn-primary" style="border-top-right-radius:2px; border-bottom-right-radius:2px;" onclick="add_count(' + rooms + ')">' +
                              '<span>+</span>' +
                          '</label>' +
                        '</div>' +
                '</div>' +
                '<div id="children' + rooms + '" class="form-group col-md-2 col-sm-3 col-xs-6">' +
                        '<label>Children</label>' +
                        '<div class="btn-group" data-toggle="buttons">' +
                           '<label class="btn btn-primary" style="border-top-left-radius:2px; border-bottom-left-radius:2px;" onclick="deduct_child_count(' + rooms + ')">' +
                              '<span>-</span>' +
                           '</label>' +
                           '<label class="btn button_white">' +
                           '<span id="childCount' + rooms + '" >0</span>' +
                            '<input type="hidden" id="childCounth' + rooms + '" name="childs[]"   value="0" />' +
                           '</label>' +
                           '<label class="btn btn-primary" style="border-top-right-radius:2px; border-bottom-right-radius:2px;" onclick="add_child_count(' + rooms + ')">' +
                              '<span>+</span>' +
                           '</label>' +
                        '</div>' +
                '</div>' +
                '<div id="age1_room' + rooms + '" class="age' + rooms + ' hide form-group col-md-2 col-sm-3 col-xs-6">' +

                        '<label>Age</label>' +
                        '<select name="age[' + rooms + '][]" class="form-control">' +
                        '<option value="0">0</option>' +
                        '<option value="1">1</option>' +
                        '<option value="2">2</option>' +
                        '<option value="3">3</option>' +
                        '<option value="4">4</option>' +
                        '<option value="5">5</option>' +
                        '<option value="6">6</option>' +
                        '<option value="7">7</option>' +
                        '<option value="8">8</option>' +
                        '<option value="9">9</option>' +
                        '<option value="10">10</option>' +
                        '</select>' +
                '</div>' +
                '<div id="age2_room' + rooms + '" class="age' + rooms + ' hide form-group col-md-2 col-sm-3 col-xs-6">' +
                '<label>Age</label>' +
                        '<select name="age[' + rooms + '][]"  class="form-control">' +
                        '<option value="0">0</option>' +
                        '<option value="1">1</option>' +
                        '<option value="2">2</option>' +
                        '<option value="3">3</option>' +
                        '<option value="4">4</option>' +
                        '<option value="5">5</option>' +
                        '<option value="6">6</option>' +
                        '<option value="7">7</option>' +
                        '<option value="8">8</option>' +
                        '<option value="9">9</option>' +
                        '<option value="10">10</option>' +
                        '</select>' +
                '</div>' +
                '</div>' +
                /*'<div class="row extrabed_room" id="extrabed_room'+rooms+'">'+
                '<div class="form-group col-md-4 col-sm-3 col-xs-6 pull-right">'+
                '<label>Cots</label><br>'+
                '<div id="period-group" class="btn-group" data-toggle="buttons">'+
                '<label class="btn button_white">'+
                '<input type="radio" onClick="setextrabed(this.value,'+rooms+')" value="Yes" > Yes'+
                '</label>'+
                '<label class="btn button_white active">'+
                '<input type="radio" onClick="setextrabed(this.value,'+rooms+')" value="No"  checked> No'+
                '</label>'+
                '</div>'+
                '<input type="hidden" id="extrabed_val_room'+rooms+'" name="extrabed[]" value="No">'+
                '</div>'+
                '</div>'+*/
                '</div>' +
                '</div>');

        if (rooms > 0) {
            $('#remove_link').show();
        }
        if (rooms == 2) {
            $('#add_link').hide();
        }
        $roomval = parseInt($('#room_count').val());
        $roomval = $roomval + 1;
        $('#room_count').val($roomval);

    }

}

function remove_rooms() {
    if (rooms > 0) {

        $('#rooms' + rooms).remove();
        rooms--;
        if (rooms == 0) {
            $('#remove_link').hide();
        }
        $roomval = parseInt($('#room_count').val());
        $roomval = $roomval - 1;
        $('#room_count').val($roomval);
    }
    if (rooms != 2) {

        $('#add_link').show();

    }
}

function childChange(room) {
    var currentValue = parseInt($("#childCount" + room).text(), 10);

    if (currentValue == 0) {
        $('.age' + room).addClass('hide');
    }
    if (currentValue == 1) {

        $('.age' + room).addClass('hide');
        $('#age1_room' + room).removeClass('hide');
    }
    else if (currentValue == 2) {
        $('.age' + room).addClass('hide');
        $('#age1_room' + room).removeClass('hide');
        $('#age2_room' + room).removeClass('hide');
    }

}

function setextrabed(val, room) {

    $('#extrabed_val_room' + room).val(val);
}
//Sum Adult&Chiuld
function _sumAdult_Chiuld() {
    //Sum Adult
    var adultCounth0 = parseInt(($('#adultCounth0').length > 0) ? $('#adultCounth0').val() : 0);
    var adultCounth1 = parseInt(($('#adultCounth1').length > 0) ? $('#adultCounth1').val() : 0);
    var adultCounth2 = parseInt(($('#adultCounth2').length > 0) ? $('#adultCounth2').val() : 0);
    adultCounth0 += adultCounth1 + adultCounth2;
    $('#sumAdult').val(adultCounth0);
    //Sum Chiuld
    var childCounth0 = parseInt(($('#childCounth0').length > 0) ? $('#childCounth0').val() : 0);
    var childCounth1 = parseInt(($('#childCounth1').length > 0) ? $('#childCounth1').val() : 0);
    var childCounth2 = parseInt(($('#childCounth2').length > 0) ? $('#childCounth2').val() : 0);
    childCounth0 += childCounth1 + childCounth2;
    $('#sumChild').val(childCounth0);
    //Sum Room
    var childCounth0 = parseInt(($('#childCounth0').length > 0) ? 1 : 0);
    var childCounth1 = parseInt(($('#childCounth1').length > 0) ? 1 : 0);
    var childCounth2 = parseInt(($('#childCounth2').length > 0) ? 1 : 0);
    childCounth0 += childCounth1 + childCounth2;
    $('#sumRoom').val(childCounth0);
    $("#select_age1_room0 option:selected").val();

}
//function umAdult_Chiuld() {
//    $('#select_age1_room0').change(function () {
//        var selectVal = $('#select_age1_room0 :selected').text();
//        alert(selectVal);
//    });
//}

//end-

//--  filter change search
$(document).ready(function() {
var arrcheck = [];
function doSubmit(obj) {
    $(obj).submit();
}
if (!Array.prototype.remove) {
    Array.prototype.remove = function (val) {
        var i = this.indexOf(val);
        return i > -1 ? this.splice(i, 1) : [];
    };
}
$('#start input[type="checkbox"]').on('ifChecked ifUnchecked', function (event) {
    var idTo = $(this).attr('id');
   
    if (event.type === "ifChecked") {
        $('input').iCheck('update');
        arrcheck.push(idTo);
        //get viewbag from input start checkbox filter-Hotels_Search_Results.cshtml
        var listRoomHotel = $(this).data('variable3');
        fillSelect(listRoomHotel);
       
       
    }
    if (event.type === "ifUnchecked") {
         arrcheck.remove(idTo);
    }
  
});
function fillSelect(listRoomHotel) {
    var start= $('#start').val();
    var end= $('#end').val();
    var sumAdult= $('#sumAdult').val();
    var sumChild= $('#sumChild').val();
    var sumRoom= $('#sumRoom').val();
    var ageChild1= $('#ageChild1').val();
    var ageChild2= $('#ageChild2').val();
    var html='';
    $.each(listRoomHotel , function (idx, obj) {
        html += '<ul class="booking-list">' +
            '<a class="booking-item" href="/hotel-details?id=' + obj.hotelSearchCode + '&price=' + obj.price + '&iHotelCode=' + obj.hotelCode + '&start='+start+'&end='+end+'&sumAdult='+sumAdult+'&sumChild='+sumChild+'&sumRoom='+sumRoom+'&ageChild1='+ageChild1+'&ageChild2='+ageChild2+'&roomType='+obj.roomType+'">'+
            '<li>' +
                 '<div class="row">' +
                     '<div class="col-md-3">' +
                         '<div class="booking-item-img-wrap">' +
                             '<img src="' + obj.thumbnail + '" alt="Image Alternative text" title="hotel 2">' +
                             '<div class="booking-item-img-num"><i class="fa fa-picture-o"></i>11</div>' +
                         '</div>' +
                     '</div>' +//end-col-md3
                     '<div class="col-md-6">' +
                        '<div class="booking-item-rating">'+
                            '<ul class="icon-group booking-item-rating-stars">'+
                                '<li>'+
                                    '<i class="fa fa-star"></i>'+
                                '</li>'+
                                '<li>'+
                                    '<i class="fa fa-star"></i>'+
                                '</li>'+
                                '<li>'+
                                    '<i class="fa fa-star"></i>'+
                                '</li>'+
                                '<li>'+
                                    '<i class="fa fa-star"></i>'+
                                '</li>'+
                                '<li>'+
                                    '<i class="fa fa-star-o"></i>'+
                               ' </li>'+
                            '</ul><span class="booking-item-rating-number"><b>'+obj.category+'</b> of 5</span>'+
                        '</div>' +
                        '<h5 class="booking-item-title">'+obj.name+'</h5>'+
                        '<p class="booking-item-address" style="margin-bottom:0"><i class="fa fa-map-marker"></i> '+obj.location+'</p><small class="booking-item-last-booked">Cancellation Deadline: '+obj.cxDeadline+'</small>'+
                        '<div id="trip">Tripadvisor</div>'+
                        '<img src="'+obj.urlImageRate+'" style="width:120px">'+
                        '<span class="booking-item-rating-number"><b>'+obj.rate+'</b> of 5</span><small> ('+obj.reviewCount+' reviews)</small>'+
                     '</div>' +// end-col-md6
                     '<div class="col-md-3">'+
                        '<span class="booking-item-price-from">from</span><span class="booking-item-price">$'+obj.price+'</span><span>/night</span><span class="btn btn-primary">Book Now</span>'+
                    '</div>'+// end-col-md3
                 '</div>' +//
             '</li>' +
             '</a>'+
          '</ul>';
    });
    $('#booklist').html(html);
}
$('body').on('', '#start input[type="checkbox"]', function () {
    var idTo = $(this).attr('id');
    //  arrcheck.push(idTo);
     alert(arrch);

    var $this = $(this);

    if ($this.is(':checked')) {
        alert('checked');
        arrcheck.push(idTo);
        alert(arrcheck.length);
    } else {
        alert('c unhecked');
        arrcheck.remove(idTo);

        alert(arrcheck.length);
    }
});
});