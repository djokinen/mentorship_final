<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Base.master" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<asp:Content ContentPlaceHolderID="ContentHead" ID="Content1" runat="server">

	<script>
		$(document).ready(function () {
			jQuery('#camera_wrap').camera({
				loader: false,
				pagination: false,
				thumbnails: false,
				height: '34.29003021148036%',
				caption: false,
				navigation: true,
				fx: 'mosaic'
			});
		});

		$(window).load(
		function () {
			$('.carousel1').carouFredSel({
				auto: false, prev: '.prev1', next: '.next1', width: 220, items: {
					visible: {
						min: 1,
						max: 2
					},
					height: 'auto',
					width: 220,

				}, responsive: true,

				scroll: 1,

				mousewheel: false,

				swipe: { onMouse: true, onTouch: true }
			});

		});

		$(function () {
			// Initialize the gallery
			$('.carousel1 a.gal').touchTouch();
		});
	</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">

	<div class="white_wrap">
		<div class="container_16">
			<div class="grid_10">
				<div class="slider_wrapper">
					<div id="camera_wrap" class="">
						<div data-src="/images-2/slide-6.jpg"></div>
						<div data-src="/images-2/slide-1.jpg"></div>
						<!--<div data-src="/images-2/slide-2.jpg"></div>-->
						<div data-src="/images-2/slide-5.jpg"></div>
						<!--
							<div data-src="/images-2/slide-3.jpg"></div>
							<div data-src="/images-2/slide-4.jpg"></div>
						-->
					</div>
				</div>
			</div>

			<div class="grid_5 prefix_1">
				<p><span class="text2">What is Mentoring?</span></p>
				<span class="text4">Mentoring</span><span class="text44"> is a process where an experienced and successful mentor will provide valuable information about their career and industry along with their personal journey in order to guide and empower the mentee (Cree Youth). It’s a chance to explore and learn about different industries and direct your life in the direction you desire.</span>
			</div>
		</div>
	</div>

	<div class="page1_block ">
		<div class="container_16">
			<!--
				<div class="grid_16 center">
					<p><span class="text2">What is Mentoring?</span></p>
					<span class="text4">Mentoring</span> is a process where an experienced and successful mentor will provide valuable information about their career and industry along with their personal journey in order to guide and empower mentee (Cree Youth). It’s a chance to explore and learn about different industries and direct your life in the direction you desire.
				</div>
				<div class="clear"></div>
			-->
			<div class="grid_4 prefix_1">
				<div class="title">Benefits of Mentoring</div>
				<img src="/images-2/page1_img1.jpg" alt="">
				This mentor program is designed to benefit the mentees by providing insight and education towards becoming the person you want to be...
				<br>
				<br>
				<a href="/mentoring.aspx" class="btn accept">read more</a>
			</div>
			<div class="grid_4 prefix_1">
				<div class="title">What Is A Mentee?</div>
				<img src="/images-2/page1_img2.jpg" alt="">
				YOU! The Cree Youth are referred to as mentees which is a person who is advised and counselled by a mentor. The concept is that mentees will have the role of...
				<br>
				<br>
				<a href="/mentee.aspx" class="btn accept">read more</a>
			</div>
			<div class="grid_4 prefix_1">
				<div class="title">What Is A Mentor?</div>
				<img src="/images-2/page1_img3.jpg" alt="">
				A mentor is an experienced advisor who’s role is to provide guidance and support to the mentees based oh his/her work experience. A good mentor will help...
				<br>
				<br>
				<a href="/mentor.aspx" class="btn accept">read more</a>
			</div>
		</div>
	</div>
</asp:Content>