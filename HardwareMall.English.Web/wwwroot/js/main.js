$(function(){
	$(".headNav li").click(function() {
				$(this).find(".hiddenMenu").toggleClass("open");
			})
			$(".menuLis li").hover(function() {
				$(this).addClass("curr").siblings().removeClass("curr");
				var index = $(this).index();
				$(".hiddenMenu ol li").eq(index).addClass("open").siblings().removeClass("open");
	})
	$(window).scroll(function(){
		var scrollH=$(window).scrollTop();
		if(scrollH>120){
			$(".header").stop().addClass("change");
		}else{
			$(".header").stop().removeClass("change");
		}
	})
	$(".goTop").click(function(){
		$('body,html').animate({scrollTop:0},500);
	})
	
	
	$(".pMenuIcon").click(function(){
			$(".pHiddenMenu").addClass("open");
		})
		$(".pHiddenMenu .closeIcon").click(function(){
			$(".pHiddenMenu").removeClass("open");
		})
		$(".pHiddenMenu ul li h4").click(function(){
			$(this).siblings().stop().slideToggle();
			$(this).parents('li').siblings().find('.twoMenu').stop().slideUp();
		})
		$(".pHiddenMenu ul li h3").click(function(){
			$(this).siblings().stop().slideToggle();
		})
		$(".pHiddenMenu ol a").click(function(){
			$(".pHiddenMenu ol").stop().slideUp();
		})
	
})
