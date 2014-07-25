$("#menu-close").click(function(e) {
    e.preventDefault();
    $("#sidebar-wrapper").toggleClass("active");
});

$("#menu-toggle").click(function(e) {
    e.preventDefault();
    $("#sidebar-wrapper").toggleClass("active");
});

$(function() {
    $('a[href*=#]:not([href=#])').click(function() {
        if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') 
        || location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
            if (target.length) {
                $('html,body').animate({
                    scrollTop: target.offset().top
                }, 1000);
                return false;
            }
        }
    });
});

window.mySwipe = new Swipe(document.getElementById('slider'), {
    disableScroll: false,
    stopPropagation: false,
    callback: function(index, elem) {},
    transitionEnd: function(index, elem) {}
});

$(document).ready(function () {
    $("#flip").click(function() {
        $("#panel").slideToggle("slow");
    });
});

/*
 $(document).ready(function() {
     $("#submitEmail").click(function() {
         $.post("send.php", $("#contactEmail").serialize(), function(response) {
             $('#success').html(response);
             var message = document.getElementById('success').innerHTML;
             if (message == "Error! Invalid Email, please provide a correct email address.") {
                 $('#success').attr("class", "alert alert-danger");
             } else { $('#success').attr("class", "alert alert-success");}
             $('#success').hide();
             $('#success').fadeIn(200);
         });
         return false;
     });
 }); */

//Google Analytics Script
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-37683254-1']);
_gaq.push(['_setDomainName', 'catch22nc.org']);
_gaq.push(['_trackPageview']);

(function () {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();