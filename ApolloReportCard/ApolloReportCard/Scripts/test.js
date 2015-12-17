//$(function () {


//    function useEverywehreAjax(options, $form) {
//        $.ajax(options).done(function (data) {
//            var $target = $($form.attr("data-search-target"));
//            var $newHtml = $(data);
//            $target.replaceWith($newHtml);// we repalced whatever data is already in the div with the new data
//            $newHtml.effect("highlight"); // this adds yellow when searching 
            
//        });
//    }

//var ajaxFormSubmitTab = function () {
//    var $form = $(this);// this puts the form in a variable
//    // this captures the url, type, data
//    var options = {
//        url: $form.attr("action"),
//        type: "get",
//        data: $form.serialize()
        
//    };

//   useEverywehreAjax(options, $form)
//    return false;
//};

//$("a[data-tab-ajax='true']").click(ajaxFormSubmitTab);// ajax request for the tabs 

//});