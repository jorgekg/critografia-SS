<?php

$email = $_POST['email'];
$password = $_POST['password'];

try {
  $conn = new PDO('mysql:host=localhost;dbname=hash', 'jorge', '');
  $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

  $stmt = $conn->query('SELECT COUNT(*) as total FROM user');
  $count = $stmt->fetch();

  $updateAt = date('Y-m-d h:i:s');
  $sal = hash('sha256', hash('sha256', $count['total'] + 1).hash('sha256', $updateAt));

  $stmt = $conn->prepare('INSERT INTO user (id, login, pass, sal, hash_pass, updateAt) values(?, ?, ?, ?, ?, ?)');
  $stmt->bindValue(1, $count['total'] + 1);
  $stmt->bindValue(2, $email);
  $stmt->bindValue(3, $password);
  $stmt->bindValue(4, $sal);
  $stmt->bindValue(5, hash('sha256', $sal.$password));
  $stmt->bindValue(6, $updateAt);
  $stmt->execute();

  echo 'Usuário inserido com sucesso';
} catch(PDOException $e) {
    echo 'ERROR: ' . $e->getMessage();
}
sleep(3);
header('Location: index.php');