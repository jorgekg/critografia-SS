<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <meta http-equiv="X-UA-Compatible" content="ie=edge">
  <title>Document</title>
</head>
<body>
  <h1>Novo usuário</h1>
  <form method="POST" action="newUser.php">
    <label>Email</label>
    <input type="text" name="email">
    <label>Senha</label>
    <input type="text" name="password">
    <button type="submit">Criar</button>
  </form>

  <h1>Login</h1>
  <form method="POST" action="login.php">
    <label>Email</label>
    <input type="text" name="email">
    <label>Senha</label>
    <input type="text" name="password">
    <button type="submit">Login</button>
  </form>
</body>
</html>