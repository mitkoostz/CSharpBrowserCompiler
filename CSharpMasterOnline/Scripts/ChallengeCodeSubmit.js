

$("#submit").click(function () {


    var number = 10;
    $(".progress").css("visibility", "visible");
    var progress = setInterval(function () {

        var w = number + "%";
        $(".progress-bar").width(w);

        if (number == 100) { clearInterval(progress) }

        number += 10;
        
    }, 100);

    $("#result").hide();
    $("#glyph").attr("class", "");
    $('#submit').attr("disabled", true);

    $.post("/Warmup/SubmitResult",
        {
            challengeId: $("#challengeId").text(),
            code: $("#codearea").val(),
            challengeName: $("#tittle").text()

        },
        function (data, status) {

            $(".progress-bar").width("100%");
            clearInterval(progress);

            setTimeout(function () {
                $(".progress-bar").width("0%");

                $(".progress").css("visibility", "hidden");

                $("#result").show();
                if (data == "Challenge Completed!") {
                    $("#result").attr("class", "text-success").text(data);
                    $("#glyph").attr("class", "glyphicon glyphicon-ok").css("color", "forestgreen");
                    $('#submit').attr("disabled", false);

                }
                if (data == "Wrong Answer!") {
                    $("#result").attr("class", "text-danger").text(data);
                    $("#glyph").attr("class", "glyphicon glyphicon-remove").css("color", "red");
                    $('#submit').attr("disabled", false);

                }
                if (data == "Compilation Error!") {
                    $("#result").attr("class", "text-danger").text(data);
                    $("#glyph").attr("class", "glyphicon glyphicon-warning-sign").css("color", "orange");
                    $('#submit').attr("disabled", false);

                }


            },700);



        });



});