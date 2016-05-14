$(document).ready(function() {
    $.get("/unFollow");
    $.get("/Follow");

    $(".dropdown-button").dropdown();

    $(".revClear").click(function(){
        $('#textarea1').val('');
    });
    $('#textarea1').trigger('autoresize');

    $('.modal-trigger').leanModal({
        dismissible: true, // Modal can be dismissed by clicking outside of the modal
        opacity: .8, // Opacity of modal background
        in_duration: 200, // Transition in duration
        out_duration: 200  
    });


    $(".comSave").hide();
    $(".RevSave").hide();
 

    $(".RevEdit").on("click", function () {
        var id = $(this).attr("Id");
        var RevText = $("#" + id + " .RevFlex").text();
        $("#" + id + " .RevFlex").html("<textarea class='materialize-textarea'>" + RevText + "</textarea>");
        $(".RevSave").show();
        $(".RevEdit").hide();

    });

    $(".RevSave").on('click', function () {
        var id = $(this).attr("id");
        var comNText = $("#" + id + " .RevFlex textarea").val();
        $.post("/EditReverie", { id: id, content: comNText }).fail(function () {

            alert("error")
        });
        $("#" + id + " .RevFlex").html(comNText);
        $(".out." + id).html(comNText);
        $(".RevSave").hide();
        $(".RevEdit").show();
    });

    $(".RevDel").on('click', function () {
        var id = $(this).attr("id");
        $.post("/DeleteReverie", { id: id }).fail(function () {

            alert("error")
        });
        $("#" + id).closeModal();
        $("#" + id + ".modal").remove();
        $(".row." + id).remove();
    });


    $(".comEdit").on("click", function () {
        var id = $(this).attr("id");
        var comText = $(".comment." + id).text();
        $(".comment." + id).html("<textarea class='materialize-textarea'>" + comText + "</textarea>");
        $("#" + id + ".comSave").show();
        $(".comEdit").hide();

    });

    $(".comSave").on('click', function () {
        var id = $(this).attr("id");
        var comNText = $(".comment." + id + " textarea").val();
        $.post("/EditComment", { id: id, content: comNText }).fail(function () {

            alert("error")
        });
        $(".comment." + id).html(comNText);
        $(".comSave").hide();
        $(".comEdit").show();
    });

    $(".comDel").on('click', function () {
        var id = $(this).attr("id");
        $.post("/DeleteComment", { id: id });
        $(".comsec." + id).remove();
    });

    $(".addCom").on('click', function () {
        var id = $(this).attr("id");
        var cont = $("#comment2").val();
        $.post("/AddComment" , { id: id , content: cont }, function (data) {

            $('.commentShow').append(data);
            $("#comment2").val("");
                       
        }).fail(function () {

            alert("error")
        });
        $(".addCom").off('click');
        return false;
    });

    $(".Likes").on('click', function () {
        if ($(this).hasClass("Like")) {
            var id = $(this).attr("id");
            var userid = $(this).attr("name");
            var count = $(this).find('span').text();
            count = parseInt(count);
            count = count + 1;
            $(this).removeClass("Like").addClass("UnLike");
            $(this).find('i').text("favorite")
            $(this).find('span').text(count + "  ");
            $.post("/Like", { id: id, userid: userid }).fail(function () {
                alert("error")
            });
            return false;
        }
        else {

            var id = $(this).attr("id");
            var userid = $(this).attr("name");
            var count = $(this).find('span').text();
            count = parseInt(count);
            count = count - 1;
            $(this).removeClass("UnLike").addClass("Like");
            $(this).find('i').text("favorite_border")
            $(this).find('span').text(count + "  ");
            $.post("/Unlike", { id: id, userid: userid }).fail(function () {
                alert("error")
            });
            return false;
        }
    });

   

    $(".profilePic").hover(function () {
        $(".editPPic").css("opacity", "1");
    }, function () {
        $(".editPPic").css("opacity", "0");
    });
    $(".editPPic").hover(function () {
        $(".editPPic").css("opacity", "1");
    }, function () {
        $(".editPPic").css("opacity", "0");
    });

    $('#bio').trigger('autoresize');

    $('#bio').trigger('autoresize');
    $('select').material_select();

    $('.datepicker').pickadate({
        selectMonths: true, // Creates a dropdown to control month
        selectYears: 15 // Creates a dropdown of 15 years to control year
    });

    $('.followbtn').on('click', function () {
        var id = $(this).attr("id");
        var pathArray = window.location.pathname.split('/');
        var ThirdLevelLocation = pathArray[2];
        $.get("/Follow", { username: ThirdLevelLocation.toString(), id: id }, function () {
            location.reload();
        }).fail(function () {
            alert("error")
        });

    });

    $('.unfollowbtn').on('click', function () {
        var id = $(this).attr("id");
        var pathArray = window.location.pathname.split('/');
        var ThirdLevelLocation = pathArray[2];
        $.get("/unFollow", { username: ThirdLevelLocation.toString(), id: id }, function () {
            location.reload();
        }).fail(function () {
            alert("error")
        });

    });

    $("#ProfileUpload").change(function () {
        var data = new FormData();
        var files = $("#ProfileUpload").get(0).files;
        if (files.length > 0) {
            var imageFile = files[0];
            var url = window.URL.createObjectURL(imageFile);
            $('#Profileimg').attr('src', url);
        }
    });

    $("#CoverUpload").change(function () {
        var data = new FormData();
        var files = $("#CoverUpload").get(0).files;
        if (files.length > 0) {
            var imageFile = files[0];
            var url = window.URL.createObjectURL(imageFile);
            $('#Coverimg').attr('src', url);
        }
    });

});