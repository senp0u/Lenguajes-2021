package cr.ac.ucr.teleatlantico.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import cr.ac.ucr.teleatlantico.service.IssueService;

@CrossOrigin(origins = "http://localhost:4200")
@RestController
@RequestMapping("issue")
public class IssueController {

	@Autowired
	private IssueService issueService;
}
