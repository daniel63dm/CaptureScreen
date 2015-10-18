// Events
$(document).ready(function(){
 $("#msg").html("This is Hello World by JQuery");
});
$(document).on('dragenter', '#dragandropzone', function() {
            $(this).css('border', '3px dashed red');
            return false;
});

$(document).on('dragover', '#dragandropzone', function(e){
            e.preventDefault();
            e.stopPropagation();
            $(this).css('border', '3px dashed red');
            return false;
});

$(document).on('dragleave', '#dragandropzone', function(e) {
            e.preventDefault();
            e.stopPropagation();
            $(this).css('border', '3px dashed #BBBBBB');
            return false;
});
// dont drop out of zone
$(document).on('dragenter', function (e)
{
    e.stopPropagation();
    e.preventDefault();
});
$(document).on('dragover', function (e)
{
  e.stopPropagation();
  e.preventDefault();
});
$(document).on('drop', function (e)
{
    e.stopPropagation();
    e.preventDefault();
});
// drop in zone
$(document).on('drop','#dragandropzone',function (e) {
    if(e.originalEvent.dataTransfer){
     if(e.originalEvent.dataTransfer.files.length) {
                 // Stop the propagation of the event
                 e.preventDefault();
                 e.stopPropagation();
                 $(this).css('border', '3px dashed green');
                 // Main function to upload
                 upload(e.originalEvent.dataTransfer.files);
     }
  }
  else {
     $(this).css('border', '3px dashed #BBBBBB');
}
return false;
})
//Functions
function upload(files) {
            var f = files[0] ;

            var reader = new FileReader();

            reader.onload = handleReaderLoad;

            reader.readAsText(f);
}

function handleReaderLoad(e) {
        var text = (e.target.result);
        obj = $.parseJSON(text);
        parsearray(obj.files);
}

function parsearray(list) {
  $.each(list, function (i,val) {
    console.log(val);
    $('#msg').append( document.createTextNode(val) );
  })
}
