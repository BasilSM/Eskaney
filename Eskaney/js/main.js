/*  ---------------------------------------------------
    Theme Name: Azenta
    Description:
    Author:
    Author URI:
    Version: 1.0
    Created:
---------------------------------------------------------  */

'use strict';

(function ($) {

    /*------------------
    Preloader
    --------------------*/
    $(window).on('load', function () {
        $(".loader").fadeOut();
        $("#preloder").delay(200).fadeOut("slow");
    });

    

    /*-------------------
		Agent Slider
    --------------------- */
    $(".agent-carousel").owlCarousel({
        items: 2,
        dots: false,
        autoplay: true,
        margin: 0,
        loop: true,
        smartSpeed: 1200,
        nav: true,
        navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        responsive: {
            320: {
                items: 1,
            },
            768: {
                items: 2,
            }
        }
    });

    

    
    

})(jQuery);