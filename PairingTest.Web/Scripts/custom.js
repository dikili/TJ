/* Sharepanel */

$(document).ready(function(){
	$(".open").click(function(){
		$(".sharepanel").slideToggle('1000',"swing");	
	});	
  
  /* Sidebar */
  
  $(".matopen").click(function(){
    $(this).next('.matter').slideToggle('1000',"swing");
  });

});

/* Navigation (Select box) */

// Create the dropdown base
$("<select />").appendTo(".navis");

// Create default option "Go to..."
$("<option />", {
   "selected": "selected",
   "value"   : "",
   "text"    : "Menu"
}).appendTo(".navis select");

// Populate dropdown with menu items
$(".navi a").each(function() {
 var el = $(this);
 $("<option />", {
     "value"   : el.attr("href"),
     "text"    : el.text()
 }).appendTo(".navis select");
});

$(".navis select").change(function() {
  window.location = $(this).find("option:selected").val();
});

/* Drop down navigation */

ddlevelsmenu.setup("ddtopmenubar", "topbar");

/* Moving sidebar below in small screens. */

$('.sidey').clone().appendTo('.mobily');


/* Flex Slider */

    $(window).load(function(){
      $('.flexslider').flexslider({
        easing: "easeInQuart",
        controlNav: false,
        start: function(slider){
          $('body').removeClass('loading');
        }
      });
    });
    
/* Pretty Photo */

jQuery(".prettyphoto").prettyPhoto({
overlay_gallery: false, 
social_tools: false
});



//$( document ).ready(function() {
//    $.getJSON("http://localhost:8080/api/questions",
//                    function (data) {
//                        // Clear the div displaying the result
//                        debugger;
//                        $(".questions").empty();
                        
//                        //Create a table and append the table body
//                        var $table = $('<table border="2">');
//                        var $tbody = $table.append('<tbody />').children('tbody');
//                        //data - return value from the Web API method
//                        for (var i = 0; i < data.QuestionsText.length; i++) {
//                            console.log(i);
//                            //add a new row to the table

//                            var $trow = $tbody.append('<tr />').children('tr:last');
//                            //add a new column to display Name
//                            var $tcol = $trow.append("<td/>").children('td:last')
//                             .append(data.QuestionsText[i]);
//                            //add a new column to display Category
//                            var $tcol = $trow.append("<td/>").children('td:last')
//                              .append(data.QuestionsText[i]);
//                            //add a new column to display Price
//                            var $tcol = $trow.append("<td/>").children('td:last')
//                             .append(data.QuestionsText[i]);
//                        }
//                      //  display the table in the div
//                        $table.appendTo(".questions");

//                    });
//});
 


