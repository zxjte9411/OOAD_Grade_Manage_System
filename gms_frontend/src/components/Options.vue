<template>
  <div v-if="isShow">
    <b-jumbotron class="mb-2" header="選擇你要的操作" lead="">
      <b-button class="mt-2 mx-2" variant="primary" @click="isShow=!isShow">成績登入</b-button>
      <b-button class="mt-2 mx-2" variant="primary" @click="isShow=!isShow">成績登入</b-button>
      <b-button class="mt-2 mx-2" variant="primary" @click="isShow=!isShow">成績登入</b-button>
      <b-button class="mt-2 mx-2" variant="primary" @click="isShow=!isShow">成績登入</b-button>
    </b-jumbotron>
  </div>
</template>

<script>
export default {
  props: {
      isShow: {
        type: Boolean
      },
  },
  methods(){

  },
};
</script>

<style>
</style>