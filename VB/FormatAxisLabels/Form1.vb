Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace FormatAxisLabels
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create an empty chart.
			Dim chartControl1 As New ChartControl()

			' Create a bar series and add points to it.
			Dim series1 As New Series("Series 1", ViewType.Bar)
			series1.Points.Add(New SeriesPoint(New DateTime(2009, 1, 1), New Double() { 26.25 }))
			series1.Points.Add(New SeriesPoint(New DateTime(2009, 2, 1), New Double() { 16.52 }))
			series1.Points.Add(New SeriesPoint(New DateTime(2009, 3, 1), New Double() { 22.21 }))
			series1.Points.Add(New SeriesPoint(New DateTime(2009, 4, 1), New Double() { 15.35 }))
			series1.Points.Add(New SeriesPoint(New DateTime(2009, 5, 1), New Double() { 24.15 }))

			' Add the series to the chart.
			chartControl1.Series.Add(series1)

			' Hide the legend (if necessary).
			chartControl1.Legend.Visible = False

			' Set the scale type for the series' arguments and values.
			series1.ArgumentScaleType = ScaleType.DateTime
			series1.ValueScaleType = ScaleType.Numerical

			' Cast the chart's diagram to the XYDiagram type, to access its axes.
			Dim diagram As XYDiagram = TryCast(chartControl1.Diagram, XYDiagram)

			' Define the date-time measurement unit, to which the beginning of 
			' a diagram's gridlines and labels should be aligned. 
			diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Day

			' Define the detail level for date-time values.
			diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month

			' Define the custom date-time format (name of a month) for the axis labels.
			diagram.AxisX.Label.TextPattern = "{V:MMMM}"

			' Since the ValueScaleType of the chart's series is Numerical,
			' it is possible to customize the NumericOptions of Y-axis.
			diagram.AxisY.Label.TextPattern = "{V:C1}"

			' Add a title to the chart (if necessary).
			Dim chartTitle1 As New ChartTitle()
			chartTitle1.Text = "Axis Scale Types"
			chartControl1.Titles.Add(chartTitle1)

			' Add the chart to the form.
			chartControl1.Dock = DockStyle.Fill
			Me.Controls.Add(chartControl1)
		End Sub

	End Class
End Namespace