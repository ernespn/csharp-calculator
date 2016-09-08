FROM mono:onbuild

EXPOSE 8083

CMD ["mono", "./CalculatorService.exe"]
