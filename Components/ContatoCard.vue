<script setup>
defineProps(["contato"]); // Recebe o amigo para mostrar
</script>

<template>
  <div class="card">
    <h3>👤 {{ contato.nome }}</h3>
    <p>📧 {{ contato.email }}</p>
    <p>📞 {{ contato.telefone }}</p>
  </div>
</template>

<style scoped>
.card {
  border: 1px solid #42b983;
  border-radius: 10px;
  padding: 10px;
  margin: 10px;
  background: #fff;
}
</style>
<script setup>