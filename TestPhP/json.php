<?php
// copy file content into a string var
$json_file = file_get_contents('http://localhost:62834/api/media?Top=10&Where=Position=1 and Active=1&Order=Ord asc');
// convert the string to a json object
$jfo = json_decode($json_file);
// read the title value
$title = $jfo->Name;
// copy the posts array to a php var
$posts = $jfo->Summary;
?>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>How to parse JSON file with PHP</title>
    <link rel="stylesheet" href="css/style.css" />
</head>

<body>
    <div class="container">
        <div class="header">
            <img src="images/BeWebDeveloper.png" />
        </div><!-- header -->
        <h1 class="main_title"><?php echo $title; ?></h1>
        <div class="content">
            <ul class="ul_json clearfix">
                <li>
                    <a href="<?php echo $jfo->Id; ?>">
                        <h2><?php echo $jfo->Name; ?></h2>
                        <img src="<?php echo $jfo->Image; ?>">
                    </a>
                </li>   
            </ul>
        </div><!-- content -->    
        <div class="footer">
            Powered by <a href="http://www.bewebdeveloper.com">bewebdeveloper.com</a>
        </div><!-- footer -->
    </div><!-- container -->
</body>
</html>
