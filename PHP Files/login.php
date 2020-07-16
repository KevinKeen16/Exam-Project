<?php

   $con = mysqli_connect('localhost', 'root', '', 'gamedata');

   if (mysqli_connect_errno()) 
   {
   	echo "1: Connection failed"; //error code #1 - connection failed
   	exit();
   }

   $username = $_POST["name"];
   $password = $_POST["password"];

   //name duplicate check
   $namecheckquery = "SELECT username, salt, hash, score FROM users  WHERE username='" . $username . "';";

   $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check failed"); //error code #2 - name check querry failed

   if(mysqli_num_rows($namecheck) != 1){
   	echo "5: Either no user with name or more than one with name"; //error code #5 - number of names is not one
   	exit();
   }
   
   //get login info from server
   $serverinfo = mysqli_fetch_assoc($namecheck);
   $salt = $serverinfo["salt"];
   $hash = $serverinfo["hash"];

   $loginhash = crypt($password, $salt);
   if ($hash != $loginhash)
   {
   	echo "6: Incorrect password"; //error code #6 - password does not hash to match table
   	exit();
   }

   echo "0\t" . $serverinfo["score"];


?>