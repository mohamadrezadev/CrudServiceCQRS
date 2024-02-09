/* sidebar */
(function($) {

	"use strict";

	var fullHeight = function() {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function(){
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

	$('#sidebarCollapse').on('click', function () {
      $('#sidebar').toggleClass('active');
  });

})(jQuery);

function openNav() {
    document.getElementById("mySidebar").style.width = "250px";
    document.getElementById("main").style.marginRight = "250px";
}

function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    document.getElementById("main").style.marginRight= "0";
    document.getElementById("main").style.marginRight= "0";
}
/* sidebar */







/* progress bar */
$(document).ready(function () {
	var delay = 800;
	$(".progress-bar").each(function (i) {
		$(this).delay(delay * i).animate({
			width: $(this).attr('aria-valuenow') + '%'
		}, delay);

		$(this).prop('Counter', 0).animate({
			Counter: $(this).text()
		}, {
			duration: delay,
			// easing: 'swing',
			step: function (now) {
				$(this).text(Math.ceil(now) + '%');
			}
		});
	});

});
/* progress bar */












