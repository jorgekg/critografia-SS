<?php

$email = $_POST['email'];
$password = $_POST['password'];

try {
  $conn = new PDO('mysql:host=localhost;dbname=hash', 'jorge', '');
  $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

  $stmt = $conn->prepare('SELECT * FROM user WHERE login = ?');
  $stmt->bindValue(1, $email);
  $stmt->execute();
  $data = $stmt->fetch();

  if (empty($data)) {
    echo 'Usuário não encontrado!';
  }

  $sal = hash('sha256', hash('sha256', $data['id']).hash('sha256', $data['updateAt']));

  if (hash('sha256', $sal.$password) === $data['hash_pass']) {
    echo 'Logado com sucesso';
  } else {
    echo 'Usuário não encontrado';
  }
} catch(PDOException $e) {
    echo 'ERROR: ' . $e->getMessage();
}