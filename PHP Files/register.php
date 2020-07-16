<?php

   $con = mysqli_connect('localhost', 'root', '', 'gamedata');

   //chekc that connection
   if (mysqli_connect_errno()) 
   {
   	echo "1: Connection failed"; //error code #1 - connection failed
   	exit();
   }

   $username = $_POST["name"];
   $password = $_POST["password"];

   //name duplicate check
   $namecheckquery = "SELECT username FROM users  WHERE username='" . $username . "';";

   $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check failed"); //error code #2 - name check querry failed

   if (mysqli_num_rows($namecheck) > 0) 
   {
   	echo "3: Name already exists"; //error code #3 - name exists cannot register
   	exit();
   }

   //add user to database
   $salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
   $hash = crypt($password, $salt);
   $insertuserquery = "INSERT INTO users (username, hash, salt) VALUES ('" . $username . "' , '" . $hash ."' , '" . $salt ."');";
   mysqli_query($con, $insertuserquery) or die("4: Player Data Insertion failed"); //error code # - player data insertion failed

   echo ("0");


?>