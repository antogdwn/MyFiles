using System;
using System.ComponentModel.DataAnnotations;

public class Taskitems
{

	public required int Id { get; set; }

	public required string Title	{ get; set; }

	public string? Description	{ get; set; }

	public DateTime DueDate { get; set; }

	public required string  Priority { get; set; }

	public required string Status { get; set; }	

   


}
