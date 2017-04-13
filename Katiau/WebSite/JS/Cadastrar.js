//JAVASCRIPT DOS BOTÕES E DO CADASTRAR
var current_fs, next_fs, previous_fs; //fieldsets
var left, opacity, scale; //fieldset properties which we will animate
var animating; //flag to prevent quick multi-click glitches

$(".next").click(function () {

    if ($("#fs1").css("display") != "none") {
        if ($("#email").val() == "") {
            $("#email").css("border-color", "#B01030");
            return false;
        }

        if ($("#senha").val() == "") {
            $("#senha").css("border-color", "#B01030");
            return false;
        }

        if ($("#csenha").val() != $("#senha").val()) {
            $("#csenha").css("border-color", "#B01030");
            return false;
        }
    }

    if ($("#fs2").css("display") != "none") {
        if ($("#nick").val() == "") {
            $("#nick").css("border-color", "#B01030");
            return false;
        }
    }

   

    if (animating) return false;

    animating = true;

    current_fs = $(this).parent();
    next_fs = $(this).parent().next();

    //activate next step on progressbar using the index of next_fs
    $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

    //show the next fieldset
    next_fs.show();
    //hide the current fieldset with style
    current_fs.animate({
        opacity: 0
    }, {
        step: function (now, mx) {
            //as the opacity of current_fs reduces to 0 - stored in "now"
            //1. scale current_fs down to 80%
            scale = 1 - (1 - now) * 0.2;
            //2. bring next_fs from the right(50%)
            left = (now * 50) + "%";
            //3. increase opacity of next_fs to 1 as it moves in
            opacity = 1 - now;
            current_fs.css({
                'transform': 'scale(' + scale + ')',
                'position': 'absolute'
            });
            next_fs.css({
                'left': left,
                'opacity': opacity
            });
        },
        duration: 800,
        complete: function () {
            current_fs.hide();
            animating = false;
        },
        //this comes from the custom easing plugin
        easing: 'easeInOutBack'
    });
});

$(".previous").click(function () {
    if (animating) return false;
    animating = true;

    current_fs = $(this).parent();
    previous_fs = $(this).parent().prev();

    //de-activate current step on progressbar
    $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

    //show the previous fieldset
    previous_fs.show();
    //hide the current fieldset with style
    current_fs.animate({
        opacity: 0
    }, {
        step: function (now, mx) {
            //as the opacity of current_fs reduces to 0 - stored in "now"
            //1. scale previous_fs from 80% to 100%
            scale = 0.8 + (1 - now) * 0.2;
            //2. take current_fs to the right(50%) - from 0%
            left = ((1 - now) * 50) + "%";
            //3. increase opacity of previous_fs to 1 as it moves in
            opacity = 1 - now;
            current_fs.css({
                'left': left
            });
            previous_fs.css({
                'transform': 'scale(' + scale + ')',
                'opacity': opacity
            });
        },
        duration: 800,
        complete: function () {
            current_fs.hide();
            animating = false;
        },
        //this comes from the custom easing plugin
        easing: 'easeInOutBack'
    });
});

$(".submit").click(function () {

    if ($("#fs3").css("display") != "none") {
        if ($("#primeironome").val() == "") {
            $("#primeironome").css("border-color", "#B01030");
            return false;
        }

        if ($("#ultimonome").val() == "") {
            $("#ultimonome").css("border-color", "#B01030");
            return false;
        }

    }

   
})

$(".datepicker").click(function(){

    var data = campoData.value;

        if (data.length == 2){
            data = data + '/';
            document.forms[0].data.value = data;
            return true;              
        }
        if (data.length == 5){
            data = data + '/';
            document.forms[0].data.value = data;
            return true;
        }

})
//# sourceURL=pen.js