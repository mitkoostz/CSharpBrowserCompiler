

$('#submit').click(function () {


    $("#loading").attr("class", "fa fa-spinner fa-spin");
    
  
        $.post("/Home/Compile",
            {
                code: $("#codearea").val()
                
            },
            function (data, status) {




                if (data.length == 0) {

                    $("#loading").attr("class", "");
                    $("#status").attr("class", "text-success").text("NO OUTPUT");
                    $('#resultdiv').css("visibility", "hidden");

                    return;
                }

                $('#resultdiv').css("visibility", "visible");

                if (data[0].hasOwnProperty("ErrorText")) {

                    $("#loading").attr("class", "");
                    $("#status").attr("class", "text-danger").text("ERROR");


                    $("#output").text(data.map(er => er.ErrorText));

                } else
                {
                    $("#loading").attr("class", "");
                    $("#status").attr("class", "text-success").text("SUCCESS");

                   

                    $("#output").html(data.join("<br />"));
                }

               

            });
   

});