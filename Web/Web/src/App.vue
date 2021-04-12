<template>
  <div>
    <TheNavbar />
    <TheHeader />
    <TheContent />
  </div>
</template>

<script>
import TheNavbar from "@/components/layout/TheNavbar";
import TheHeader from "@/components/layout/TheHeader";
import TheContent from "@/components/layout/TheContent";

export default {
  name: "App",
  components: {
    TheNavbar,
    TheHeader,
    TheContent,
  },
};
</script>

<style>
@import "./styles/index.css";
</style>
