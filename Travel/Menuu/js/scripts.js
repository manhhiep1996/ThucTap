jQuery(document).ready(function(){
	if ( jQuery(window).width() < 1200  ) {
		jQuery('.shop-by-content').on("click",".filter-box p",function(){
			if ( $(this).attr('aria-expanded') == 'true' ) {
				$(this).attr('aria-expanded','false');
				$(this).parent().children('ul').slideUp();
			} else {
				$(this).attr('aria-expanded','true');
				$(this).parent().children('ul').slideDown();
			}
		});
		jQuery('.btn-navbar-collection').click(function() {

			var chk = 0;
			if ( $('#navbar-inner').hasClass('navbar-inactive') && ( chk==0 ) ) {
				$('#navbar-inner').removeClass('navbar-inactive');
				$('#navbar-inner').addClass('navbar-active');
				$('#cssmenu').css('display','block');
				chk = 1;
			}
			if ($('#navbar-inner').hasClass('navbar-active') && ( chk==0 ) ) {
				$('#navbar-inner').removeClass('navbar-active');
				$('#navbar-inner').addClass('navbar-inactive');			
				$('#cssmenu').css('display','none');
				chk = 1;
			}
			//$('#ma-mobilemenu').slideToggle();
		}); 
		jQuery('.filter-title-coll').click(function() {

			var chk = 0;
			if ( $('#filter-shop-by').hasClass('navbar-inactive') && ( chk==0 ) ) {
				$('#filter-shop-by').removeClass('navbar-inactive');
				$('#filter-shop-by').addClass('navbar-active');
				$('#tags-filter-content').css('display','block');
				chk = 1;
			}
			if ($('#filter-shop-by').hasClass('navbar-active') && ( chk==0 ) ) {
				$('#filter-shop-by').removeClass('navbar-active');
				$('#filter-shop-by').addClass('navbar-inactive');			
				$('#tags-filter-content').css('display','none');
				chk = 1;
			}
			//$('#ma-mobilemenu').slideToggle();
		}); 


	}

})

jQuery(document).ready(function () {
    jQuery(document).ready(function ($) {
        $("nav.mobile select").change(function () { window.location = jQuery(this).val(); });
        $(document).ready(function () {
            jQuery(window).scroll(function () {
                if ($(this).scrollTop() > 100) {
                    $('.scrollToTop').addClass('show');
                } else {
                    $('.scrollToTop').removeClass('show');
                }
            });

            //Click event to scroll to top
            jQuery('.scrollToTop').on('click', function () {
                jQuery("html, body").animate({ scrollTop: 0 }, "slow");
            });
        })
    })
})