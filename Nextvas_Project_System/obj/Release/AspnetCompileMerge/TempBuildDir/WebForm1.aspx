<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Nextvas_Project_System.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>

</head>
<body>

	<!-- CSS -->
    <style>
    #my_camera{
        width: 320px;
        height: 240px;
        border: 1px solid black;
    }
	</style>

	<!-- -->
	<div id="my_camera"></div>
	<input type="button" value="Configure" onclick="configure()"/>
	<input type="button" value="Take Snapshot" onclick="take_snapshot()"/>
	<input type="button" value="Save Snapshot" onclick="saveSnap()"/>
	
    <div id="results"  ></div>
	
	<!-- Script -->
	<script type="text/javascript" src="webcamjs/webcam.min.js"></script>

	<!-- Code to handle taking the snapshot and displaying it locally -->
	<script language="JavaScript">

        // Configure a few settings and attach camera
        function configure() {
            Webcam.set({
                width: 320,
                height: 240,
                image_format: 'jpeg',
                jpeg_quality: 90
            });
            Webcam.attach('#my_camera');
        }
        // A button for taking 
        function take_snapshot() {
            // take snapshot and get image data
            Webcam.snap(function (data_uri) {
                // display results in page
                document.getElementById('results').innerHTML =
                    '<img id="imageprev" src="' + data_uri + '"/>';
            });

            Webcam.reset();
        }

        function saveSnap() {
            //// Get base64 value from <img id='imageprev'> source
            //var base64image =  document.getElementById("imageprev").src;
            //Webcam.upload(base64image,)
            //Webcam.upload(base64image, 'upload.php', function (code, text)
            //{
            //	 console.log('Save successfully');
            //	 //console.log(text);
            //         });

            //var file = document.getElementById("imageprev").src;
            //var formdata = new FormData();
            //formdata.append("imageprev", file);
            //var ajax = new XMLHttpRequest();
            //ajax.addEventListener("load", function (event) { uploadcomplete(event); }, false);
            //ajax.open("POST", "upload.php");
            //ajax.send(formdata);

            //Webcam.snap(function (data) {
            //    // display results in page
            //    document.getElementById('results').innerHTML = '<img src="' + data_uri + '"/>';
            //    // Send image data to the controller to store locally or in database
            //    Webcam.upload(data,
            //        '/Pages/WebForm1',
            //        function (code, text) {
            //            alert('Snapshot/Image captured successfully...');
            //        });
            //});

            var base64data = $("#my_camera").val();
            $.ajax({
                type: "POST",
                dataType: "json",
                url: "upload.php",
                data: { image: base64data },
                success: function (data) {
                    alert(data);
                }
            });

        }
	</script>
	
</body>
</html>
