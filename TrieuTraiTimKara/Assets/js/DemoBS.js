
var sourceMainOrgin;
var captionMain;
var describeMain;



// // Instantiate the Bootstrap carousel
// $('.multi-item-carousel').carousel({
//   interval: false
// });

// // for every slide in carousel, copy the next slide's item in the slide.
// // Do the same for the next, next item.
// $('.multi-item-carousel .item').each(function(){
//   var next = $(this).next();
//   if (!next.length) {
//     next = $(this).siblings(':first');
//   }
//   next.children(':first-child').clone().appendTo($(this));
  
//   if (next.next().length>0) {
//     next.next().children(':first-child').clone().appendTo($(this));
//   } else {
//   	$(this).siblings(':first').children(':first-child').clone().appendTo($(this));
//   }
// });

function changeCSSwhenclicksong(id)
{
	var classname=".R1sub2_"+id;
	

	var getptag=classname+" p";
	$(classname).css("background","#87D9F5");
	$(getptag).css("font-style","italic");
}
function removeCSSwhenout(id)
{
	

	for(var i=2;i<=7;i++)
		{
			var tagclass=".R1sub2_"+i;
			var getptag=tagclass+" p";
			if(i==id) continue;
			else
			{
				$(tagclass).css("background","none");
				$(getptag).css("font-style","normal");

			}
		}
}	
$(document).ready(function()
{
	$(".firstsong").click(function(event)
	{
		event.preventDefault();
		var mp3link=$(".firstsong").attr("href");
		$(".audioplayer").attr("src",mp3link);
		$(".audioplayer")[0].play();

		$(".contentSong").text(function(i,origText)
		{
			var songname=$(".R1sub2_2 p:first").text();
			var singer=$(".R1sub2_2 p:eq(1)").text();

			return songname+" - "+singer;

		});

		changeCSSwhenclicksong(2);
		

		removeCSSwhenout(2);

		
	});

	$(".secondsong").click(function(event)
	{
		event.preventDefault();
		var mp3link=$(".secondsong").attr("href");
		$(".audioplayer").attr("src",mp3link);
		$(".audioplayer")[0].play();

		$(".contentSong").text(function(i,origText)
		{
			var songname=$(".R1sub2_3 p:first").text();
			var singer=$(".R1sub2_3 p:eq(1)").text();

			return songname+" - "+singer;

		});

		changeCSSwhenclicksong(3);
		removeCSSwhenout(3);
		
		
	});
	$(".thirdsong").click(function(event)
	{
		event.preventDefault();
		var mp3link=$(".thirdsong").attr("href");
		$(".audioplayer").attr("src",mp3link);
		$(".audioplayer")[0].play();

		$(".contentSong").text(function(i,origText)
		{
			var songname=$(".R1sub2_4 p:first").text();
			var singer=$(".R1sub2_4 p:eq(1)").text();

			return songname+" - "+singer;

		});

		changeCSSwhenclicksong(4);
		removeCSSwhenout(4);
		
		
	});
	$(".foursong").click(function(event)
	{
		event.preventDefault();
		var mp3link=$(".foursong").attr("href");
		$(".audioplayer").attr("src",mp3link);
		$(".audioplayer")[0].play();

		$(".contentSong").text(function(i,origText)
		{
			var songname=$(".R1sub2_5 p:first").text();
			var singer=$(".R1sub2_5 p:eq(1)").text();

			return songname+" - "+singer;

		});

		changeCSSwhenclicksong(5);
		removeCSSwhenout(5);
		
		
	});
	$(".fivesong").click(function(event)
	{
		event.preventDefault();
		var mp3link=$(".fivesong").attr("href");
		$(".audioplayer").attr("src",mp3link);
		$(".audioplayer")[0].play();

		$(".contentSong").text(function(i,origText)
		{
			var songname=$(".R1sub2_6 p:first").text();
			var singer=$(".R1sub2_6 p:eq(1)").text();

			return songname+" - "+singer;

		});

		changeCSSwhenclicksong(6);
		removeCSSwhenout(6);
		
		
	});
	$(".sixsong").click(function(event)
	{
		event.preventDefault();
		var mp3link=$(".sixsong").attr("href");
		$(".audioplayer").attr("src",mp3link);
		$(".audioplayer")[0].play();

		$(".contentSong").text(function(i,origText)
		{
			var songname=$(".R1sub2_7 p:first").text();
			var singer=$(".R1sub2_7 p:eq(1)").text();

			return songname+" - "+singer;

		});

		changeCSSwhenclicksong(7);
		removeCSSwhenout(7);
		
		
	});

	$(".TruyCapNhanh").click(function(event){
		event.preventDefault();
		$("body").animate({
			scrollTop:$("footer").offset().top});

		return false;
		});
	
});